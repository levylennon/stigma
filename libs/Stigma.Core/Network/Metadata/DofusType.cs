using Stigma.Core.IO.Binary;

namespace Stigma.Core.Network.Metadata;

public abstract class DofusType
{
    public const ushort ProtocolTypeId = 0;
    
    public abstract ushort ProtocolId { get; }
    
    public abstract void Serialize(BigEndianWriter writer);
    
    public abstract void Deserialize(BigEndianReader reader);
}