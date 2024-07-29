namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyKickRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5592;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int PlayerId { get; set; }

    public PartyKickRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(PlayerId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        PlayerId = reader.ReadInt32();
    }
}