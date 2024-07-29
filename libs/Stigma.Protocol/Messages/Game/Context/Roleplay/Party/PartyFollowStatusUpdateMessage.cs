namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyFollowStatusUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5581;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Success { get; set; }

    public required int FollowedId { get; set; }

    public PartyFollowStatusUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Success);
        writer.WriteInt32(FollowedId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Success = reader.ReadBoolean();
        FollowedId = reader.ReadInt32();
    }
}