using System.Diagnostics;
using Stigma.Tools.ProtocolBuilder.Models.Kinds;

namespace Stigma.Tools.ProtocolBuilder.Models.Symbols;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TypeSymbol
{
    public required string Namespace { get; set; }

    public required string Name { get; set; }

    public required string ParentName { get; set; }

    public required string Source { get; set; }

    public required SymbolKind SymbolKind { get; set; }

    public override string ToString()
    {
        return $"Namespace: {Namespace}, Name: {Name}, Kind: {SymbolKind}, ParentName: {ParentName}";
    }
}