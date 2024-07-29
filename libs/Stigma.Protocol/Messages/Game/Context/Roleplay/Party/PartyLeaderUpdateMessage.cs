namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyLeaderUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5578;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int PartyLeaderId { get; set; }

    public PartyLeaderUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(PartyLeaderId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        PartyLeaderId = reader.ReadInt32();
    }
}