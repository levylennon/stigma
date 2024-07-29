using Stigma.Tools.ProtocolBuilder.Models.Kinds;
using Stigma.Tools.ProtocolBuilder.Models.Symbols;
using Stigma.Tools.ProtocolBuilder.Storages.Regexes;

namespace Stigma.Tools.ProtocolBuilder.Services.Parsers.Enums;

public sealed class EnumParser : IParser
{
    private readonly IRegexStorage _regexStorage;

    public EnumParser(IRegexStorage regexStorage)
    {
        _regexStorage = regexStorage;
    }

    public ClassSymbol Parse(TypeSymbol typeSymbol)
    {
        var matches = _regexStorage.Matches(RegexKind.EnumProperty, typeSymbol.Source).ToArray();

        var properties = new List<PropertySymbol>();

        for (var index = 0; index < matches.Length; index++)
        {
            var match = matches[index];

            if (!match.Groups.TryGetValue("name", out var name))
                throw new Exception($"{typeSymbol.Name} has invalid property {nameof(name)}.");

            if (!match.Groups.TryGetValue("type", out var type))
                throw new Exception($"{typeSymbol.Name} has invalid property {nameof(type)}.");

            if (!match.Groups.TryGetValue("value", out var value))
                throw new Exception($"{typeSymbol.Name} has invalid property {nameof(value)}.");

            properties.Add(new PropertySymbol
            {
                Name = name.Value,
                Type = type.Value,
                Value = ParseValue(value.Value),
                Index = index
            });
        }

        return new ClassSymbol
        {
            Type = typeSymbol,
            Imports = [],
            Items = [],
            Properties = properties
        };
    }

    private static string ParseValue(string value)
    {
        return value.StartsWith("0x") ? Convert.ToInt64(value, 16).ToString() : Convert.ToInt64(value).ToString();
    }
}