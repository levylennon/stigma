namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightLeaveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 721;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int CharId { get; set; }

    public GameFightLeaveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(CharId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CharId = reader.ReadInt32();
    }
}