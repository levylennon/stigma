namespace Stigma.Protocol.Messages.Game.Interactive.Zaap;

public sealed class ZaapListMessage : TeleportDestinationsListMessage
{
    public new const uint ProtocolMessageId = 1604;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int SpawnMapId { get; set; }

    public ZaapListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(SpawnMapId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        SpawnMapId = reader.ReadInt32();
    }
}