namespace Stigma.Protocol.Messages.Game.Context.Roleplay;

public sealed class ChangeMapMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 221;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int MapId { get; set; }

    public ChangeMapMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(MapId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MapId = reader.ReadInt32();
    }
}