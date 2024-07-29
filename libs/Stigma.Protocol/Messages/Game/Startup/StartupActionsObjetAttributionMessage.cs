namespace Stigma.Protocol.Messages.Game.Startup;

public sealed class StartupActionsObjetAttributionMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1303;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short ActionId { get; set; }

    public required int CharacterId { get; set; }

    public StartupActionsObjetAttributionMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(ActionId);
        writer.WriteInt32(CharacterId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ActionId = reader.ReadInt16();
        CharacterId = reader.ReadInt32();
    }
}