namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses;

public sealed class HouseKickIndoorMerchantRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5661;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short CellId { get; set; }

    public HouseKickIndoorMerchantRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(CellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CellId = reader.ReadInt16();
    }
}