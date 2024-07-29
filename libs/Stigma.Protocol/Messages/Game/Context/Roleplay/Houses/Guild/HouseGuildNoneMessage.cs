namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses.Guild;

public sealed class HouseGuildNoneMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5701;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short HouseId { get; set; }

    public HouseGuildNoneMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(HouseId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        HouseId = reader.ReadInt16();
    }
}