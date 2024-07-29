namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightCastRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1005;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short SpellId { get; set; }

    public required short CellId { get; set; }

    public GameActionFightCastRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(SpellId);
        writer.WriteInt16(CellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SpellId = reader.ReadInt16();
        CellId = reader.ReadInt16();
    }
}