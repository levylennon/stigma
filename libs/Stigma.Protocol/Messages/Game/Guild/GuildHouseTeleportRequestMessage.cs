namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildHouseTeleportRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5712;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int HouseId { get; set; }

    public GuildHouseTeleportRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(HouseId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        HouseId = reader.ReadInt32();
    }
}