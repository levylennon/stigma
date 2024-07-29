namespace Stigma.Protocol.Messages.Game.Actions;

public sealed class GameActionAcknowledgementMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 957;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Valid { get; set; }

    public required int ActionId { get; set; }

    public GameActionAcknowledgementMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Valid);
        writer.WriteInt32(ActionId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Valid = reader.ReadBoolean();
        ActionId = reader.ReadInt32();
    }
}