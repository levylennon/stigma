namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Emote;

public sealed class EmotePlayRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5685;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte EmoteId { get; set; }

    public EmotePlayRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(EmoteId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        EmoteId = reader.ReadInt8();
    }
}