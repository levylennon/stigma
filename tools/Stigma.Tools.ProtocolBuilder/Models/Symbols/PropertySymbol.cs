using System.Diagnostics;
using Stigma.Tools.ProtocolBuilder.Models.Kinds;

namespace Stigma.Tools.ProtocolBuilder.Models.Symbols;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PropertySymbol
{
    public required string Name { get; set; }

    public required string Type { get; set; }

    public required AccessorKind AccessorKind { get; set; }

    public required int Index { get; set; }

    public string? Value { get; set; }

    public PropertyKind? PropertyKind { get; set; }

    public MethodKind? MethodKind { get; set; }

    public string? ReadMethod { get; set; }

    public string? WriteMethod { get; set; }

    public string? VectorFieldRead { get; set; }

    public string? VectorFieldWrite { get; set; }

    public string? ObjectType { get; set; }

    public int? VectorLength { get; set; }

    public bool Nullable { get; set; }

    public bool VectorUseICollection { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Type: {Type}, AccessorKind: {AccessorKind}, Index: {Index}";
    }
}