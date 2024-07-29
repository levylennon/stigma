namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyFollowThisMemberRequestMessage : PartyFollowMemberRequestMessage
{
    public new const uint ProtocolMessageId = 5588;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Enabled { get; set; }

    public PartyFollowThisMemberRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteBoolean(Enabled);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Enabled = reader.ReadBoolean();
    }
}