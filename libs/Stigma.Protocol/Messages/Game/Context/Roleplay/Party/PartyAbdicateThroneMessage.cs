namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyAbdicateThroneMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6080;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int PlayerId { get; set; }

    public PartyAbdicateThroneMessage()
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