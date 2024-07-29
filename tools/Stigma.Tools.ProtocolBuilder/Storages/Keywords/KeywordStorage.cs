using System.Collections.Frozen;
using Humanizer;

namespace Stigma.Tools.ProtocolBuilder.Storages.Keywords;

public sealed class KeywordStorage : IKeywordStorage
{
    private readonly FrozenDictionary<string, string> _as3MethodsToCSharpMethods = new Dictionary<string, string>
    {
        ["boolean"] = "Boolean",
        ["byte"] = "Int8",
        ["double"] = "Double",
        ["float"] = "Float",
        ["int"] = "Int32",
        ["short"] = "Int16",
        ["unsignedint"] = "UInt32",
        ["unsignedshort"] = "UInt16",
        ["unsignedbyte"] = "UInt8",
        ["utf"] = "Utf",
        ["utfbytes"] = "UtfBytes",
        ["string"] = "Utf",
        ["uint"] = "UInt32",
        ["number"] = "Double",
        ["bytearray"] = "Bytes"
    }.ToFrozenDictionary();

    private readonly FrozenDictionary<string, string> _methodsToType = new Dictionary<string, string>
    {
        ["unsignedbyte"] = "byte",
        ["unsignedshort"] = "ushort",
        ["boolean"] = "bool",
        ["byte"] = "sbyte",
        ["sbyte"] = "sbyte",
        ["double"] = "double",
        ["float"] = "float",
        ["uint8"] = "byte",
        ["int8"] = "sbyte",
        ["int"] = "int",
        ["int32"] = "int",
        ["uint"] = "uint",
        ["uint32"] = "uint",
        ["short"] = "short",
        ["int16"] = "short",
        ["ushort"] = "ushort",
        ["uint16"] = "ushort",
        ["long"] = "long",
        ["int64"] = "long",
        ["ulong"] = "ulong",
        ["uint64"] = "ulong",
        ["utf"] = "string",
        ["utfbytes"] = "string",
        ["stringbytes"] = "string",
        ["number"] = "double",
        ["string"] = "string"
    }.ToFrozenDictionary();

    public string GetMethod(string as3, string method, string replaceWith)
    {
        return _as3MethodsToCSharpMethods.TryGetValue(as3.ToLower().Replace(method, string.Empty), out var csharp)
            ? $"{replaceWith.Pascalize()}{csharp}"
            : $"{replaceWith.Pascalize()}{as3}";
    }

    public string GetType(string method, string prefix)
    {
        return _methodsToType.TryGetValue(method.ToLower().Replace(prefix, string.Empty), out var type)
            ? type
            : method.ToLower();
    }
}