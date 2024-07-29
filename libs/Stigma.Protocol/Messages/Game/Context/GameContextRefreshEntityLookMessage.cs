using Stigma.Protocol.Types.Game.Look;

namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameContextRefreshEntityLookMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5637;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Id { get; set; }

    public required EntityLook Look { get; set; }

    public GameContextRefreshEntityLookMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
        Look.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadInt32();
        Look = new EntityLook();
        Look.Deserialize(reader);
    }
}