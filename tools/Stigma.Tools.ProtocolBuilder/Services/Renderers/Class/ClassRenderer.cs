using Microsoft.Extensions.Options;
using Stigma.Core.IO.Text;
using Stigma.Tools.ProtocolBuilder.Extensions;
using Stigma.Tools.ProtocolBuilder.Models.Kinds;
using Stigma.Tools.ProtocolBuilder.Models.Symbols;
using Stigma.Tools.ProtocolBuilder.Options;
using Stigma.Tools.ProtocolBuilder.Storages.Symbols;

namespace Stigma.Tools.ProtocolBuilder.Services.Renderers.Class;

public sealed class ClassRenderer : IRenderer
{
    private readonly string _namespace;
    private readonly ISymbolStorage _symbolStorage;

    public ClassRenderer(ISymbolStorage symbolStorage, IOptions<GlobalOptions> options)
    {
        _symbolStorage = symbolStorage;
        _namespace = options.Value.Namespace;
    }

    public string Render(ClassSymbol classSymbol)
    {
        var builder = new IndentedStringBuilder();

        RenderImports(classSymbol, builder);

        if (builder.Length > 0)
            builder.AppendLine();

        classSymbol.Type.ParentName = classSymbol.Type.ParentName switch
        {
            "NetworkMessage" => "DofusMessage",
            "NetworkType" => "DofusType",
            _ => classSymbol.Type.ParentName
        };

        var canBeSealed = _symbolStorage.GetClassSymbols().All(x => x.Type.ParentName != classSymbol.Type.Name);

        var protocolIdPropertyType = classSymbol.Type.Name.EndsWith("Message") ? "uint" : "ushort";
        var protocolIdPropertyName = classSymbol.Type.Name.EndsWith("Message") ? "ProtocolMessageId" : "ProtocolTypeId";

        builder
            .AppendLine("namespace {0};", classSymbol.Type.Namespace)
            .AppendLine()
            .AppendLine("public {0}class {1} : {2}", canBeSealed ? "sealed " : string.Empty, classSymbol.Type.Name, classSymbol.Type.ParentName)
            .AppendLine('{')
            .Indent()
            .AppendLineIndented("public new const {0} {1} = {2};", protocolIdPropertyType, protocolIdPropertyName, classSymbol.Items["id"])
            .AppendLine()
            .AppendLineIndented("public override {0} ProtocolId =>", protocolIdPropertyType)
            .Indent()
            .AppendLineIndented("{0};", protocolIdPropertyName)
            .UnIndent()
            .AppendLine();

        RenderProperties(classSymbol, builder);
        RenderConstructor(classSymbol, builder);

        RenderSerializeMethod(classSymbol, builder);
        RenderDeserializeMethod(classSymbol, builder);

        builder
            .UnIndent()
            .AppendLine('}');

        return builder.ToString();
    }

    private void RenderImports(ClassSymbol symbol, IndentedStringBuilder builder)
    {
        var importSets = new List<string>();

        foreach (var import in symbol.Imports)
        {
            var importNs = import.Split('.')[0];

            if (importNs.Contains("Enums") || importNs.Contains("enums"))
                continue;

            if (_namespace.Contains(importNs))
            {
                builder.AppendLine("using {0};", import);
                continue;
            }

            if (import.Contains("version"))
            {
                builder.AppendLine("using Version = {0}.Types.Version.Version;", _namespace);
                continue;
            }

            var usingNs = $"using {_namespace}.{string.Join('.', import.PascalizeNamespace().Split('.')[..^1])};";

            if (importSets.Contains(usingNs))
                continue;

            importSets.Add(usingNs);
        }

        if (importSets.Count is 0)
            return;

        foreach (var importSet in importSets)
            builder.AppendLine(importSet);
    }

    private static void RenderProperties(ClassSymbol symbol, IndentedStringBuilder builder)
    {
        if (symbol.Type.Name is "NetworkDataContainerMessage")
            builder
                .AppendLineIndented("public required byte[] Content { get; set; }")
                .AppendLine();

        var useRequired = symbol.Type.Name.EndsWith("Message");

        foreach (var property in symbol.Properties)
        {
            if (string.IsNullOrEmpty(property.ObjectType))
                property.ObjectType = property.Type;

            switch (property.PropertyKind)
            {
                case PropertyKind.Primitive:
                case PropertyKind.Object:
                    builder.AppendLineIndented("public {2}{0} {1} {{ get; set; }}", property.ObjectType, property.Name.PascalizeWithSpecialChars(),
                        useRequired ? "required " : string.Empty);
                    break;
                case PropertyKind.Vector:
                    builder.AppendLineIndented("public {2}IEnumerable<{0}> {1} {{ get; set; }}", property.ObjectType, property.Name.PascalizeWithSpecialChars(),
                        useRequired ? "required " : string.Empty);
                    break;
                default:
                    throw new Exception("Unknown property kind.");
            }

            builder.AppendLine();
        }
    }

    private static void RenderConstructor(ClassSymbol symbol, IndentedStringBuilder builder)
    {
        builder.AppendLineIndented("public {0}() {{ }}", symbol.Type.Name);
    }

    private static void RenderSerializeMethod(ClassSymbol symbol, IndentedStringBuilder builder)
    {
        builder
            .AppendLine()
            .AppendLineIndented("public override void Serialize(BigEndianWriter writer)")
            .AppendLineIndented('{')
            .Indent();

        if (HaveCustomParent(symbol))
            builder.AppendLineIndented("base.Serialize(writer);");

        var flags = symbol.Properties.Count(x => x.MethodKind is MethodKind.BooleanByteWrapper);
        var flagsDone = 0;

        if (flags > 0)
            builder.AppendLineIndented("var flag = new byte();");

        if (symbol.Type.Name is "NetworkDataContainerMessage")
            builder.AppendLineIndented("writer.WriteBytes(Content);");

        foreach (var property in symbol.Properties)
            switch (property.PropertyKind)
            {
                case PropertyKind.Primitive:
                    switch (property.MethodKind)
                    {
                        case MethodKind.VectorPrimitive:
                        case MethodKind.SerializeOrDeserialize:
                        case MethodKind.ProtocolTypeManager:
                            break;
                        case MethodKind.Primitive:
                            builder.AppendLineIndented("writer.{0}({1});", property.WriteMethod!, property.Name.PascalizeWithSpecialChars());
                            break;
                        case MethodKind.BooleanByteWrapper:
                            if (flagsDone is not 0 && flagsDone % 8 is 0)
                                builder.AppendLineIndented("flag = new byte();");

                            builder.AppendLineIndented("flag = BooleanByteWrapper.SetFlag(flag, {0}, {1});", Convert.ToUInt32(property.ReadMethod),
                                property.Name.PascalizeWithSpecialChars());

                            flags--;
                            flagsDone++;

                            if (flags is 0 || flagsDone % 8 is 0)
                                builder.AppendLineIndented("writer.WriteUInt8(flag);");
                            continue;
                        default:
                            if (property.Type is not "byte[]")
                                throw new Exception("Unknown method kind.");

                            builder.AppendLineIndented("writer.WriteInt16((short){0}.Length);", property.Name.PascalizeWithSpecialChars());
                            builder.AppendLineIndented("writer.WriteBytes({0});", property.Name.PascalizeWithSpecialChars());
                            continue;
                    }

                    break;
                case PropertyKind.Object:
                    switch (property.MethodKind)
                    {
                        case MethodKind.Primitive:
                        case MethodKind.VectorPrimitive:
                        case MethodKind.BooleanByteWrapper:
                        case MethodKind.SerializeOrDeserialize:
                            break;
                        case MethodKind.ProtocolTypeManager:
                            builder.AppendLineIndented("writer.WriteUInt16({0}.ProtocolId);", property.Name.PascalizeWithSpecialChars());
                            break;
                        default:
                            throw new Exception("Unknown method kind.");
                    }

                    builder.AppendLineIndented("{0}.Serialize(writer);", property.Name.PascalizeWithSpecialChars());
                    break;
                case PropertyKind.Vector:
                    RenderSerializeVector(property, builder);
                    break;
                default:
                    throw new Exception("Unknown property kind.");
            }

        builder
            .UnIndent()
            .AppendLineIndented('}');
    }

    private static void RenderSerializeVector(PropertySymbol property, IndentedStringBuilder builder)
    {
        builder
            .AppendLineIndented("var {0}Before = writer.Position;", property.Name)
            .AppendLineIndented("var {0}Count = 0;", property.Name);

        if (!property.VectorLength.HasValue)
        {
            if (property.VectorFieldWrite is not null)
                builder.AppendLineIndented("writer.{0}(0);", property.VectorFieldWrite);
            else
                builder.AppendLineIndented("writer.WriteInt16(0);");
        }

        builder
            .AppendLineIndented("foreach (var item in {0})", property.Name.PascalizeWithSpecialChars())
            .AppendLineIndented('{')
            .Indent();

        switch (property.MethodKind)
        {
            case MethodKind.Primitive:
            case MethodKind.BooleanByteWrapper:
                break;
            case MethodKind.ProtocolTypeManager:
                builder
                    .AppendLineIndented("writer.WriteUInt16(item.ProtocolId);")
                    .AppendLineIndented("item.Serialize(writer);");
                break;
            case MethodKind.VectorPrimitive:
                builder.AppendLineIndented("writer.{0}(item);", property.WriteMethod!);
                break;
            case MethodKind.SerializeOrDeserialize:
                builder.AppendLineIndented("item.Serialize(writer);");
                break;
            default:
                builder.AppendLineIndented("item.Serialize(writer);");
                break;
        }

        builder
            .AppendLineIndented("{0}Count++;", property.Name)
            .UnIndent()
            .AppendLineIndented('}')
            .AppendLineIndented("var {0}After = writer.Position;", property.Name)
            .AppendLineIndented("writer.Seek(SeekOrigin.Begin, {0}Before);", property.Name);

        if (!property.VectorLength.HasValue)
        {
            if (property.VectorFieldWrite is not null)
                builder.AppendLineIndented("writer.{0}((short){1}Count);", property.VectorFieldWrite, property.Name);
            else
                builder.AppendLineIndented("writer.WriteInt16((short){0}Count);", property.Name);
        }

        builder.AppendLineIndented("writer.Seek(SeekOrigin.Begin, {0}After);", property.Name);
    }

    private void RenderDeserializeMethod(ClassSymbol symbol, IndentedStringBuilder builder)
    {
        builder
            .AppendLine()
            .AppendLineIndented("public override void Deserialize(BigEndianReader reader)")
            .AppendLineIndented('{')
            .Indent();

        if (HaveCustomParent(symbol))
            builder.AppendLineIndented("base.Deserialize(reader);");

        var flags = symbol.Properties.Count(x => x.MethodKind is MethodKind.BooleanByteWrapper);
        var flagsDone = 0;

        if (flags > 0)
            builder.AppendLineIndented("var flag = reader.ReadUInt8();");

        if (symbol.Type.Name is "NetworkDataContainerMessage")
            builder.AppendLineIndented("Content = Core.IO.Compression.ZipCompressor.UncompressV2(reader.ReadBytes(reader.ReadUInt16()));");

        foreach (var property in symbol.Properties)
            switch (property.PropertyKind)
            {
                case PropertyKind.Primitive:
                    switch (property.MethodKind)
                    {
                        case MethodKind.VectorPrimitive:
                        case MethodKind.SerializeOrDeserialize:
                        case MethodKind.ProtocolTypeManager:
                            break;
                        case MethodKind.Primitive:
                            builder.AppendLineIndented("{0} = reader.{1}();", property.Name.PascalizeWithSpecialChars(), property.ReadMethod!);
                            break;
                        case MethodKind.BooleanByteWrapper:
                            builder.AppendLineIndented("{0} = BooleanByteWrapper.GetFlag(flag, {1});", property.Name.PascalizeWithSpecialChars(),
                                Convert.ToUInt32(property.ReadMethod));

                            flags--;
                            flagsDone++;

                            if (flagsDone is not 0 && flagsDone % 8 is 0)
                                builder.AppendLine("flag = reader.ReadUInt8();");
                            continue;
                        default:
                            if (property.Type is not "byte[]")
                                continue;

                            builder.AppendLineIndented("{0} = reader.ReadBytes(reader.ReadUInt16());", property.Name.PascalizeWithSpecialChars());
                            continue;
                    }

                    break;
                case PropertyKind.Object:
                    switch (property.MethodKind)
                    {
                        case MethodKind.Primitive:
                        case MethodKind.VectorPrimitive:
                        case MethodKind.BooleanByteWrapper:
                            break;
                        case MethodKind.SerializeOrDeserialize:
                            builder.AppendLineIndented("{0} = new {1}();", property.Name.PascalizeWithSpecialChars(), property.ObjectType!);
                            break;
                        case MethodKind.ProtocolTypeManager:
                            builder
                                .AppendLineIndented("{0} = DofusTypeFactory.CreateInstance<{1}>(reader.ReadUInt16());", property.Name.PascalizeWithSpecialChars(),
                                    property.ObjectType!)
                                .AppendLineIndented("{0}.Deserialize(reader);", property.Name.PascalizeWithSpecialChars());
                            continue;
                        default:
                            throw new Exception("Unknown method kind.");
                    }

                    builder.AppendLineIndented("{0}.Deserialize(reader);", property.Name.PascalizeWithSpecialChars());
                    break;
                case PropertyKind.Vector:
                    RenderDeserializeVector(symbol, property, builder);
                    break;
                default:
                    throw new Exception("Unknown property kind.");
            }

        builder
            .UnIndent()
            .AppendLineIndented('}');
    }

    private void RenderDeserializeVector(ClassSymbol currentSymbol, PropertySymbol property, IndentedStringBuilder builder)
    {
        var vectorLengthVar = $"{property.Name}Count";

        if (!property.VectorLength.HasValue)
        {
            if (property.VectorFieldRead is null)
                builder.AppendLineIndented("var {0} = reader.ReadInt16();", vectorLengthVar);
            else
                builder.AppendLineIndented("var {0} = reader.{1}();", vectorLengthVar, property.VectorFieldRead);
        }
        else
        {
            vectorLengthVar = property.VectorLength.ToString();
        }

        var objectType = property.ObjectType;

        if (GetFullProperties(currentSymbol).Any(x => x.Name.PascalizeWithSpecialChars() == property.ObjectType) && property.ObjectType is not null)
            if (_symbolStorage.TryGetClassSymbol(property.ObjectType, out var symbol))
                objectType = string.Concat(symbol.Type.Namespace[1..].PascalizeNamespace(), '.', property.ObjectType);

        builder
            .AppendLineIndented("var {0} = new {1}[{2}];", property.Name, property.ObjectType!, vectorLengthVar!)
            .AppendLineIndented("for (var i = 0; i < {0}; i++)", vectorLengthVar!)
            .AppendLineIndented('{')
            .Indent();

        switch (property.MethodKind)
        {
            case MethodKind.Primitive:
            case MethodKind.VectorPrimitive:
            case MethodKind.BooleanByteWrapper:
                break;
            case MethodKind.ProtocolTypeManager:
                builder.AppendLineIndented("var entry = DofusTypeFactory.CreateInstance<{0}>(reader.ReadUInt16());", objectType!);
                break;
            case null:
            case MethodKind.SerializeOrDeserialize:
                builder.AppendLineIndented("var entry = new {0}();", objectType!);
                break;
            default:
                builder
                    .AppendLineIndented("entry.Deserialize(reader);")
                    .AppendLineIndented("{0}[i] = entry;", property.Name);
                break;
        }

        switch (property.MethodKind)
        {
            case MethodKind.VectorPrimitive:
                builder.AppendLineIndented("{0}[i] = reader.{1}();", property.Name, property.ReadMethod!);
                break;
            case MethodKind.Primitive:
            case MethodKind.SerializeOrDeserialize:
            case MethodKind.ProtocolTypeManager:
            case MethodKind.BooleanByteWrapper:
                builder
                    .AppendLineIndented("entry.Deserialize(reader);")
                    .AppendLineIndented("{0}[i] = entry;", property.Name);
                break;
            default:
                builder
                    .AppendLineIndented("entry.Deserialize(reader);")
                    .AppendLineIndented("{0}[i] = entry;", property.Name);
                break;
        }

        builder
            .UnIndent()
            .AppendLineIndented('}')
            .AppendLineIndented("{0} = {1};", property.Name.PascalizeWithSpecialChars(), property.Name);
    }

    private PropertySymbol[] GetFullProperties(ClassSymbol symbol)
    {
        var propertiesParentConstructor = new List<PropertySymbol>();

        if (HaveCustomParent(symbol))
        {
            _symbolStorage.TryGetClassSymbol(symbol.Type.ParentName, out var parentClass);

            while (parentClass is not null)
            {
                propertiesParentConstructor.AddRange(parentClass.Properties.ToArray().Reverse());
                _symbolStorage.TryGetClassSymbol(parentClass.Type.ParentName, out parentClass);
            }
        }

        propertiesParentConstructor.Reverse();

        return propertiesParentConstructor
            .Concat(symbol.Properties)
            .ToArray();
    }

    private static bool HaveCustomParent(ClassSymbol symbol)
    {
        return symbol.Type.ParentName != "DofusMessage" &&
               symbol.Type.ParentName != "DofusType";
    }
}