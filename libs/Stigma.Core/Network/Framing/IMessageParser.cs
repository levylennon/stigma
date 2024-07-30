using System.Diagnostics.CodeAnalysis;
using Stigma.Core.Network.Metadata;

namespace Stigma.Core.Network.Framing;

public interface IMessageParser
{
    bool TryDecodeMessage(ref Memory<byte> sequence, [NotNullWhen(true)] out DofusMessage? message);

    ReadOnlyMemory<byte> EncodeMessage(DofusMessage message);
}