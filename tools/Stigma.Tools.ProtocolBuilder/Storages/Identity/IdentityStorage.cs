using System.Diagnostics.CodeAnalysis;

namespace Stigma.Tools.ProtocolBuilder.Storages.Identity;

public sealed class IdentityStorage : IIdentityStorage
{
    public bool TryGetId(string name, [NotNullWhen(true)] out string? id)
    {
        throw new NotImplementedException();
    }
}