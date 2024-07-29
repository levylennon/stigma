using System.Text.RegularExpressions;
using Stigma.Tools.ProtocolBuilder.Models.Kinds;

namespace Stigma.Tools.ProtocolBuilder.Storages.Regexes;

public sealed partial class RegexStorage : IRegexStorage
{
    public bool IsMatch(RegexKind kind, string input)
    {
        return GetRegex(kind).IsMatch(input);
    }

    public Match Match(RegexKind kind, string input)
    {
        return GetRegex(kind).Match(input);
    }

    public IEnumerable<Match> Matches(RegexKind kind, string input)
    {
        return GetRegex(kind).Matches(input);
    }

    private static Regex GetRegex(RegexKind type)
    {
        return type switch
        {
            RegexKind.Metadata => Metadata(),
            RegexKind.Namespace => Namespace(),
            RegexKind.Import => Import(),
            RegexKind.EnumProperty => EnumProperty(),
            RegexKind.PropertyPrimitive => PropertyPrimitive(),
            RegexKind.PropertyObject => PropertyObject(),
            RegexKind.PropertyVector => PropertyVector(),
            RegexKind.PropertyVectorFieldWriteLength => PropertyVectorFieldWriteLength(),
            RegexKind.PropertyVectorFieldWriteMethod => PropertyVectorFieldWriteMethod(),
            RegexKind.ReadMethodPrimitive => ReadMethodPrimitive(),
            RegexKind.ReadVectorMethodObject => ReadVectorMethodObject(),
            RegexKind.ReadVectorMethodProtocolManager => ReadVectorMethodProtocolManager(),
            RegexKind.ReadMethodObjectProtocolManager => ReadMethodObjectProtocolManager(),
            RegexKind.VarVectorLimitLength => VarVectorLimitLength(),
            RegexKind.ReadFlagMethod => ReadFlagMethod(),
            RegexKind.ProtocolId => ProtocolId(),
            RegexKind.ThrowError => ThrowError(),
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };
    }

    [GeneratedRegex(@"public\s*[final]*\s+class\s+(?<name>[\w]+)\s*[extends]*\s*(?<parent>[\w]*)\s[implements\s+]*(?<interface>[\w]*)\s*,*\s*(?<interface2>[\w]*)",
        RegexOptions.Multiline)]
    private static partial Regex Metadata();

    [GeneratedRegex(@"package\s+(?<name>[\w|\.]+)", RegexOptions.Multiline)]
    private static partial Regex Namespace();

    [GeneratedRegex(@"import\s+(?<name>[\w|\.]+)\s*;", RegexOptions.Multiline)]
    private static partial Regex Import();

    [GeneratedRegex(@"public\s+static\s+const\s+(?<name>[\w|_]+):(?<type>[\w]+)\s+=\s+(?<value>[-+\d\w]+);", RegexOptions.Multiline)]
    private static partial Regex EnumProperty();

    [GeneratedRegex(@"public\s+var\s+(?<name>[\w]+)\s*:\s*(?<type>String|Boolean|int|Number|uint|byte|ByteArray)", RegexOptions.Multiline)]
    private static partial Regex PropertyPrimitive();

    [GeneratedRegex(@"public\s+var\s+(?<name>[\w]+):(?!(String|Boolean|int|Number|uint|byte|ByteArray|Vector)\b)(?<type>[\w]+)", RegexOptions.Multiline)]
    private static partial Regex PropertyObject();

    [GeneratedRegex(@"public\s+var\s+(?<name>\w+):Vector\.<(?<type>\w+)>;", RegexOptions.Multiline)]
    private static partial Regex PropertyVector();

    [GeneratedRegex(@"(output|param1)\.(?<method>\w+)\(this\.(?<name>\w+)\.length\);", RegexOptions.Multiline)]
    private static partial Regex PropertyVectorFieldWriteLength();

    [GeneratedRegex(@"(output|param1)\.(?<method>\w+)\(this.(?<name>\w+)\[", RegexOptions.Multiline)]
    private static partial Regex PropertyVectorFieldWriteMethod();

    [GeneratedRegex(@"this.(?<name>\w+)\s*=\s*(input|param1)\.(?<method>\w+)\(\);", RegexOptions.Multiline)]
    private static partial Regex ReadMethodPrimitive();

    [GeneratedRegex(@"_\w+\s*=\s*new\s+(?<type>[\w]+)\(\)\s*;\s*\n\s*_\w+.deserialize\((input|param1)\)\s*;\s*\n\s*this.(?<name>[\w]+).push\(_\w+\)\s*;", RegexOptions.Multiline)]
    private static partial Regex ReadVectorMethodObject();

    [GeneratedRegex(
        @"while\(.*\n\s*.*\s*.*(input|param1)\.readUnsignedShort\(\)\);\n\s.*=\s*ProtocolTypeManager\.getInstance\((?<type>\w+),.*\n\s*.*\.deserialize\((input|param1)\);\n\s*this\.(?<name>\w+)\.push",
        RegexOptions.Multiline)]
    private static partial Regex ReadVectorMethodProtocolManager();

    [GeneratedRegex(@"this.(?<name>[\w]+)\s*=\s*ProtocolTypeManager.getInstance\(\s*(?<type>[\w]+)", RegexOptions.Multiline)]
    private static partial Regex ReadMethodObjectProtocolManager();

    [GeneratedRegex(@"while.*<\s*(?<value>[\d]+).*\n\s*.*\n.*this.(?<name>[\w]+)\[", RegexOptions.Multiline)]
    private static partial Regex VarVectorLimitLength();

    [GeneratedRegex(@"this.(?<name>[\w]+)\s*=\s*BooleanByteWrapper\.getFlag\(_[\w\d]+,\s*(?<flag>[\d]+)\)")]
    private static partial Regex ReadFlagMethod();

    [GeneratedRegex(@"public\s*static\s*const\s*protocolId:uint\s*=\s*(?<value>[\w]+)\s*;", RegexOptions.Multiline)]
    private static partial Regex ProtocolId();

    [GeneratedRegex(@"throw\s+new\s+Error\s+\(")]
    private static partial Regex ThrowError();
}