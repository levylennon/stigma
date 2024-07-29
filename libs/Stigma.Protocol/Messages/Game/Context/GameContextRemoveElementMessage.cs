namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameContextRemoveElementMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 251;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Id { get; set; }

    public GameContextRemoveElementMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadInt32();
    }
}