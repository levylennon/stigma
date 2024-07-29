namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyMemberRemoveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5579;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int LeavingPlayerId { get; set; }

    public PartyMemberRemoveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(LeavingPlayerId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        LeavingPlayerId = reader.ReadInt32();
    }
}