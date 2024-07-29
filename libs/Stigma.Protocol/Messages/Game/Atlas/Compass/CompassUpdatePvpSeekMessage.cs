namespace Stigma.Protocol.Messages.Game.Atlas.Compass;

public sealed class CompassUpdatePvpSeekMessage : CompassUpdateMessage
{
    public new const uint ProtocolMessageId = 6013;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int MemberId { get; set; }

    public required string MemberName { get; set; }

    public CompassUpdatePvpSeekMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(MemberId);
        writer.WriteUtf(MemberName);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MemberId = reader.ReadInt32();
        MemberName = reader.ReadUtf();
    }
}