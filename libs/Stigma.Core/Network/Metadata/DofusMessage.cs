using Stigma.Core.IO.Binary;

namespace Stigma.Core.Network.Metadata;

public abstract class DofusMessage
{
    public const uint ProtocolMessageId = 0;
    
    public abstract uint ProtocolId { get; }
    
    public abstract void Serialize(BigEndianWriter writer);
    
    public abstract void Deserialize(BigEndianReader reader);
}