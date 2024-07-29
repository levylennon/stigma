namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyCannotJoinErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5583;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public PartyCannotJoinErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Reason);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Reason = reader.ReadInt8();
    }
}