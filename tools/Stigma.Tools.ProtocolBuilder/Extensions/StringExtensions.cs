using Humanizer;

namespace Stigma.Tools.ProtocolBuilder.Extensions;

public static class StringExtensions
{
    public static string NamespaceToPath(this string @namespace)
    {
        return Path.Combine(@namespace.Split('.', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Pascalize()).ToArray());
    }

    public static string PascalizeWithSpecialChars(this string text)
    {
        if (text.Length > 2 && text[0] is '@')
            return string.Concat(char.ToUpper(text[1]).ToString(), text.AsSpan(2));

        return text.Pascalize();
    }

    public static string PascalizeNamespace(this string str)
    {
        return string.IsNullOrEmpty(str)
            ? string.Empty
            : string.Join('.', str.Split('.').Select(x => x.Pascalize()));
    }

    public static string ToValidName(this string s)
    {
        return s switch
        {
            "object" => $"@{s}",
            "base" => $"@{s}",
            "params" => $"@{s}",
            _ => s
        };
    }
}