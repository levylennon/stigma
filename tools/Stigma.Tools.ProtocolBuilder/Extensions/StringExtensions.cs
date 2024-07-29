using Humanizer;

namespace Stigma.Tools.ProtocolBuilder.Extensions;

public static class StringExtensions
{
    public static string NamespaceToPath(this string @namespace)
    {
        return Path.Combine(@namespace.Split('.', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Pascalize()).ToArray());
    }
}