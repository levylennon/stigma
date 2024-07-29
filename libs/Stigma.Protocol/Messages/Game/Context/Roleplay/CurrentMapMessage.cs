namespace Stigma.Protocol.Messages.Game.Context.Roleplay;

public sealed class CurrentMapMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 220;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int MapId { get; set; }

    public CurrentMapMessage()
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