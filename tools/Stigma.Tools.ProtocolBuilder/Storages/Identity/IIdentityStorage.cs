using System.Diagnostics.CodeAnalysis;

namespace Stigma.Tools.ProtocolBuilder.Storages.Identity;

public interface IIdentityStorage
{
    bool TryGetId(string name, [NotNullWhen(true)] out string? id);
}