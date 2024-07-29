using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Stigma.Tools.ProtocolBuilder.Models.Kinds;
using Stigma.Tools.ProtocolBuilder.Models.Symbols;
using Stigma.Tools.ProtocolBuilder.Storages.Keywords;
using Stigma.Tools.ProtocolBuilder.Storages.Regexes;

namespace Stigma.Tools.ProtocolBuilder.Services.Parsers.Classes;

public sealed class ClassParser : IParser
{
    private readonly IKeywordStorage _keywordStorage;
    private readonly IRegexStorage _regexStorage;

    public ClassParser(IRegexStorage regexStorage, IKeywordStorage keywordStorage)
    {
        _regexStorage = regexStorage;
        _keywordStorage = keywordStorage;
    }

    public ClassSymbol Parse(TypeSymbol typeSymbol)
    {
        var symbol = new ClassSymbol
        {
            Imports = ParseImports(typeSymbol),
            Items = new Dictionary<string, string>
            {
                ["id"] = ParseProtocolId(typeSymbol)
            },
            Type = typeSymbol,
            Properties = []
        };

        ParseProperties(symbol);
        ParseMethods(symbol);

        symbol.Properties = symbol.Properties.OrderBy(x => x.Index).ToList();

        return symbol;
    }

    private string ParseProtocolId(TypeSymbol typeSymbol)
    {
        var match = _regexStorage.Match(RegexKind.ProtocolId, typeSymbol.Source);

        if (!match.Groups.TryGetValue("value", out var valueGroup))
            throw new Exception($"{typeSymbol.Name} has invalid protocol id {nameof(valueGroup)}.");

        return valueGroup.Value.StartsWith("0x")
            ? Convert.ToUInt32(valueGroup.Value, 16).ToString()
            : uint.Parse(valueGroup.Value).ToString();
    }

    private List<string> ParseImports(TypeSymbol typeSymbol)
    {
        var imports = new List<string>();

        foreach (var match in _regexStorage.Matches(RegexKind.Import, typeSymbol.Source))
        {
            if (!match.Groups.TryGetValue("name", out var nameGroup))
                throw new Exception($"{typeSymbol.Name} has invalid import {nameof(nameGroup)}.");

            if (!nameGroup.Value.Contains("dofus.network"))
                continue;

            if (nameGroup.Value.Contains("ProtocolTypeManager"))
                continue;

            imports.Add(nameGroup.Value.Replace("com.ankamagames.dofus.network.", string.Empty));
        }

        imports.Remove("using Stigma.Protocol.Enums;");

        return imports;
    }

    private void ParseProperties(ClassSymbol symbol)
    {
        ParsePropertiesPrimitive(symbol);
        ParsePropertiesObject(symbol);
        ParsePropertiesVector(symbol);
    }

    private void ParsePropertiesPrimitive(ClassSymbol symbol)
    {
        foreach (var match in _regexStorage.Matches(RegexKind.PropertyPrimitive, symbol.Type.Source))
        {
            if (!EnsurePropertyIsValid(symbol, match, out var nameGroup, out var typeGroup))
                continue;

            symbol.Properties.Add(new PropertySymbol
            {
                Name = nameGroup.Value,
                Type = typeGroup.Value,
                PropertyKind = PropertyKind.Primitive,
                Index = nameGroup.Index
            });
        }
    }

    private void ParsePropertiesObject(ClassSymbol symbol)
    {
        foreach (var match in _regexStorage.Matches(RegexKind.PropertyObject, symbol.Type.Source))
        {
            if (!EnsurePropertyIsValid(symbol, match, out var nameGroup, out var typeGroup))
                continue;

            switch (typeGroup.Value)
            {
                case "String":
                case "ByteArray":
                    continue;
                default:
                    symbol.Properties.Add(new PropertySymbol
                    {
                        Name = nameGroup.Value,
                        Type = typeGroup.Value,
                        PropertyKind = PropertyKind.Object,
                        Index = nameGroup.Index,
                        MethodKind = MethodKind.SerializeOrDeserialize,
                        ReadMethod = "Deserialize",
                        WriteMethod = "Serialize",
                        ObjectType = typeGroup.Value
                    });
                    break;
            }
        }
    }

    private void ParsePropertiesVector(ClassSymbol symbol)
    {
        foreach (var match in _regexStorage.Matches(RegexKind.PropertyVector, symbol.Type.Source))
        {
            if (!EnsurePropertyIsValid(symbol, match, out var nameGroup, out var typeGroup))
                continue;

            symbol.Properties.Add(new PropertySymbol
            {
                Name = nameGroup.Value,
                Type = typeGroup.Value,
                PropertyKind = PropertyKind.Vector,
                Index = nameGroup.Index
            });
        }
    }

    private void ParseMethods(ClassSymbol symbol)
    {
        ParseMethodVector(symbol);

        ParseMethodPrimitive(symbol);

        ParseMethodVectorObject(symbol);

        ParseMethodProtocolObject(symbol, RegexKind.ReadVectorMethodProtocolManager);
        ParseMethodProtocolObject(symbol, RegexKind.ReadMethodObjectProtocolManager);

        ParseMethodVectorLength(symbol);
        ParseBooleanByteWrapper(symbol);
    }

    private void ParseMethodVector(ClassSymbol symbol)
    {
        var content = GetContentInsideMethod(symbol, "serializeAs_");

        foreach (var match in _regexStorage.Matches(RegexKind.PropertyVectorFieldWriteLength, content))
        {
            EnsurePropertyExist(symbol, match, out var property);

            EnsureMethodIsValid(symbol, match, out var methodGroup);

            property.VectorFieldRead = _keywordStorage.GetMethod(methodGroup.Value, "write", "read");
            property.VectorFieldWrite = _keywordStorage.GetMethod(methodGroup.Value, "write", "write");
        }

        foreach (var match in _regexStorage.Matches(RegexKind.PropertyVectorFieldWriteMethod, content))
        {
            EnsurePropertyExist(symbol, match, out var property);

            EnsureMethodIsValid(symbol, match, out var methodGroup);

            property.WriteMethod = _keywordStorage.GetMethod(methodGroup.Value, "write", "write");
            property.ReadMethod = _keywordStorage.GetMethod(methodGroup.Value, "write", "read");
            property.MethodKind = MethodKind.VectorPrimitive;
        }
    }

    private void ParseMethodPrimitive(ClassSymbol symbol)
    {
        foreach (var match in _regexStorage.Matches(RegexKind.ReadMethodPrimitive, symbol.Type.Source))
        {
            EnsurePropertyExist(symbol, match, out var property);

            EnsureMethodIsValid(symbol, match, out var methodGroup);

            property.ReadMethod = _keywordStorage.GetMethod(methodGroup.Value, "read", "read");
            property.WriteMethod = _keywordStorage.GetMethod(methodGroup.Value, "read", "write");
            property.ObjectType = _keywordStorage.GetType(property.ReadMethod, "read");
            property.MethodKind = MethodKind.Primitive;
        }
    }

    private void ParseMethodVectorObject(ClassSymbol symbol)
    {
        foreach (var match in _regexStorage.Matches(RegexKind.ReadVectorMethodObject, symbol.Type.Source))
        {
            EnsurePropertyExist(symbol, match, out var property);

            if (!match.Groups.TryGetValue("type", out var typeGroup))
                throw new Exception($"{symbol.Type.Name} has invalid property {nameof(typeGroup)}.");

            property.ReadMethod = "Deserialize";
            property.WriteMethod = "Serialize";
            property.ObjectType = typeGroup.Value;
            property.MethodKind = MethodKind.SerializeOrDeserialize;
        }
    }

    private void ParseMethodProtocolObject(ClassSymbol symbol, RegexKind kind)
    {
        foreach (var match in _regexStorage.Matches(kind, symbol.Type.Source))
        {
            EnsurePropertyExist(symbol, match, out var property);

            if (!match.Groups.TryGetValue("type", out var typeGroup))
                throw new NullReferenceException($"{symbol.Type.Name} has invalid {nameof(typeGroup)}.");

            property.ObjectType = typeGroup.Value;
            property.MethodKind = MethodKind.ProtocolTypeManager;
        }
    }

    private void ParseMethodVectorLength(ClassSymbol symbol)
    {
        foreach (var match in _regexStorage.Matches(RegexKind.VarVectorLimitLength, symbol.Type.Source))
        {
            EnsurePropertyExist(symbol, match, out var property);

            if (match.Groups.TryGetValue("minValue", out var value))
                property.VectorLength = int.Parse(value.Value);
        }
    }

    private void ParseBooleanByteWrapper(ClassSymbol symbol)
    {
        var lines = (symbol.Type.Source + "\n\n\n\n").Split("\n");

        for (var index = 0; index < lines.Length - 4; index++)
        {
            var line = lines[index];

            var match = _regexStorage.Match(RegexKind.ReadFlagMethod, line);

            if (!match.Success)
                continue;

            if (!match.Groups.TryGetValue("name", out var nameGroup))
                throw new Exception($"{symbol.Type.Name} has invalid BooleanWrapper {nameof(nameGroup)}.");

            if (!match.Groups.TryGetValue("flag", out var flagGroup))
                throw new Exception($"{symbol.Type.Name} has invalid BooleanWrapper {nameof(flagGroup)}.");

            EnsurePropertyExist(symbol, match, out var property);

            property.ObjectType = "bool";
            property.MethodKind = MethodKind.BooleanByteWrapper;
            property.ReadMethod = flagGroup.Value;
            property.WriteMethod = flagGroup.Value;
            property.Index = nameGroup.Index;
        }
    }

    private static void EnsurePropertyExist(ClassSymbol symbol, Match match, out PropertySymbol property)
    {
        if (!match.Groups.TryGetValue("name", out var nameGroup))
            throw new Exception($"{symbol.Type.Name} has invalid property {nameof(nameGroup)}.");

        var expectedProperty = symbol.Properties.FirstOrDefault(x => x.Name == nameGroup.Value);

        property = expectedProperty ?? throw new NullReferenceException($"{symbol.Type.Name} property {nameGroup.Value} not found.");
    }

    private static void EnsureMethodIsValid(ClassSymbol symbol, Match match, out Group methodGroup)
    {
        if (!match.Groups.TryGetValue("method", out var expectedMethodGroup))
            throw new Exception($"{symbol.Type.Name} has invalid method {nameof(expectedMethodGroup)}.");

        methodGroup = expectedMethodGroup;
    }

    private static bool EnsurePropertyIsValid(
        ClassSymbol symbol,
        Match match,
        [NotNullWhen(true)] out Group? nameGroup,
        [NotNullWhen(true)] out Group? typeGroup)
    {
        if (!match.Groups.TryGetValue("name", out nameGroup))
            throw new Exception($"{symbol.Type.Name} has invalid property {nameof(nameGroup)}.");

        if (!match.Groups.TryGetValue("type", out typeGroup))
            throw new Exception($"{symbol.Type.Name} has invalid property {nameof(typeGroup)}.");

        return true;
    }

    private static string GetContentInsideMethod(ClassSymbol symbol, string methodName)
    {
        var fileLines = symbol.Type.Source.Split("\n");
        var brackets = FindBracketsIndexesByLines(fileLines, '{', '}');
        var bracketOpen = Array.FindIndex(fileLines, entry => entry.Contains($"function {methodName}"));

        if (!fileLines[bracketOpen].EndsWith('{'))
            bracketOpen++;

        var bracketClose = brackets[bracketOpen];
        var methodLines = new string[bracketClose - 1 - bracketOpen];

        Array.Copy(fileLines, bracketOpen + 1, methodLines, 0, bracketClose - 1 - bracketOpen);

        return methodLines
            .Where(line => line.Trim() != string.Empty)
            .Aggregate(string.Empty, (current, line) => current + (line + (char)10));
    }

    private static Dictionary<int, int> FindBracketsIndexesByLines(string[] lines, char startSeparator, char endSeparator)
    {
        var elementsStack = new Stack<int>();
        var result = new Dictionary<int, int>();

        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(startSeparator))
                elementsStack.Push(i);

            if (!lines[i].Contains(endSeparator))
                continue;

            result.Add(elementsStack.Pop(), i);
        }

        return result;
    }
}