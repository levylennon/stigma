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
            RegexKind.EnumProperty => EnumProperty(),
            RegexKind.ThrowError => ThrowError(),
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };
    }

    [GeneratedRegex(@"public\s*[final]*\s+class\s+(?<name>[\w]+)\s*[extends]*\s*(?<parent>[\w]*)\s[implements\s+]*(?<interface>[\w]*)\s*,*\s*(?<interface2>[\w]*)",
        RegexOptions.Multiline)]
    private static partial Regex Metadata();

    [GeneratedRegex(@"package\s+(?<name>[\w|\.]+)", RegexOptions.Multiline)]
    private static partial Regex Namespace();
    
    [GeneratedRegex(@"public\s+static\s+const\s+(?<name>[\w|_]+):(?<type>[\w]+)\s+=\s+(?<value>[-+\d\w]+);", RegexOptions.Multiline)]
    private static partial Regex EnumProperty();

    [GeneratedRegex(@"throw\s+new\s+Error\s+\(")]
    private static partial Regex ThrowError();
}