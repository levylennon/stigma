namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Emote;

public sealed class EmotePlayMessage : EmotePlayAbstractMessage
{
    public new const uint ProtocolMessageId = 5683;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ActorId { get; set; }

    public EmotePlayMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(ActorId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        ActorId = reader.ReadInt32();
    }
}