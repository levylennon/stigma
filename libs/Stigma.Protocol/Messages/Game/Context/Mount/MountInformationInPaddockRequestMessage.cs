namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountInformationInPaddockRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5975;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int MapRideId { get; set; }

    public MountInformationInPaddockRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(MapRideId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MapRideId = reader.ReadInt32();
    }
}