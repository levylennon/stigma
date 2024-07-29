namespace Stigma.Protocol.Messages.Game.Atlas.Compass;

public sealed class CompassUpdatePartyMemberMessage : CompassUpdateMessage
{
    public new const uint ProtocolMessageId = 5589;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int MemberId { get; set; }

    public CompassUpdatePartyMemberMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(MemberId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MemberId = reader.ReadInt32();
    }
}