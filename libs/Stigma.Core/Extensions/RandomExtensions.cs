using System.Text;

namespace Stigma.Core.Extensions;

public static class RandomExtensions
{
    public static string NextString(this Random random, int length)
    {
        var builder = new StringBuilder();
        
        for (var i = 0; i < length; i++)
            builder.Append((char)Math.Floor(26 * random.NextDouble() + 65));

        return builder.ToString();
    }
}