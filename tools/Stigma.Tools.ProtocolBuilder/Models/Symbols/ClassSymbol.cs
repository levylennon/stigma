using System.Diagnostics;

namespace Stigma.Tools.ProtocolBuilder.Models.Symbols;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ClassSymbol
{
    public required TypeSymbol Type { get; set; }

    public required List<string> Imports { get; set; }

    public required List<PropertySymbol> Properties { get; set; }

    public required Dictionary<string, string> Items { get; set; }

    public override string ToString()
    {
        return $"{Type}, Imports: {Imports.Count}, Properties: {Properties.Count}, Items: {Items.Count}";
    }
}