using Microsoft.Extensions.Options;
using Stigma.Tools.ProtocolBuilder.Extensions;
using Stigma.Tools.ProtocolBuilder.Models.Kinds;
using Stigma.Tools.ProtocolBuilder.Models.Symbols;
using Stigma.Tools.ProtocolBuilder.Options;
using Stigma.Tools.ProtocolBuilder.Storages.Keywords;

namespace Stigma.Tools.ProtocolBuilder.Services.Converters.Classes;

public sealed class ClassConverter : IConverter
{
    private readonly IKeywordStorage _keywordStorage;
    private readonly GlobalOptions _options;

    public ClassConverter(IKeywordStorage keywordStorage, IOptions<GlobalOptions> options)
    {
        _keywordStorage = keywordStorage;
        _options = options.Value;
    }

    public void Convert(ClassSymbol classSymbol)
    {
        classSymbol.Type.Namespace = string.Concat(_options.Namespace, classSymbol.Type.Namespace.PascalizeNamespace());

        foreach (var property in classSymbol.Properties)
        {
            property.Name = property.Name switch
            {
                "object" => "@object",
                "params" => "@params",
                "base" => "@base",
                "messageId" => "@messageId",
                "typeId" => "@typeId",
                "lock" => "@lock",
                _ => property.Name
            };

            property.ObjectType = property.ObjectType switch
            {
                "Version" => "Version",
                "Shortcut" => "Types.Game.Shortcut.Shortcut",
                _ => property.ObjectType
            };

            var pascalizedPropertyName = property.Name.PascalizeWithSpecialChars();

            if (pascalizedPropertyName == property.ObjectType)
                property.Name += "Value";

            if (property is { PropertyKind: PropertyKind.Vector, MethodKind: MethodKind.VectorPrimitive, ObjectType: null, WriteMethod: not null })
                property.ObjectType = _keywordStorage.GetType(property.WriteMethod!, "write");

            if (property is { Type: "String", PropertyKind: PropertyKind.Vector })
            {
                property.ObjectType = "string";
                property.MethodKind = MethodKind.VectorPrimitive;
                property.ReadMethod = "ReadUtf";
                property.WriteMethod = "WriteUtf";
            }
        }
    }
}