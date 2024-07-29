namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Emote;

public class EmotePlayAbstractMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5690;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte EmoteId { get; set; }

    public required byte Duration { get; set; }

    public EmotePlayAbstractMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(EmoteId);
        writer.WriteUInt8(Duration);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        EmoteId = reader.ReadInt8();
        Duration = reader.ReadUInt8();
    }
}