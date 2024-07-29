using System.Diagnostics.CodeAnalysis;
using Stigma.Core.Network.Metadata;

namespace Stigma.Core.Network.Factory;

public interface IMessageFactory
{
    bool TryCreateInstance(uint id, [NotNullWhen(true)] out DofusMessage? message);
}