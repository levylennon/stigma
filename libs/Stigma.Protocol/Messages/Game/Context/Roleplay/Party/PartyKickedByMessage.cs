namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyKickedByMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5590;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int KickerId { get; set; }

    public PartyKickedByMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(KickerId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        KickerId = reader.ReadInt32();
    }
}