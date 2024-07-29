namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyInvitationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5586;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int FromId { get; set; }

    public required string FromName { get; set; }

    public required int ToId { get; set; }

    public required string ToName { get; set; }

    public PartyInvitationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(FromId);
        writer.WriteUtf(FromName);
        writer.WriteInt32(ToId);
        writer.WriteUtf(ToName);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FromId = reader.ReadInt32();
        FromName = reader.ReadUtf();
        ToId = reader.ReadInt32();
        ToName = reader.ReadUtf();
    }
}