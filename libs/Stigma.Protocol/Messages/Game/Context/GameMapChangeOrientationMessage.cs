namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameMapChangeOrientationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 946;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Id { get; set; }

    public required sbyte Direction { get; set; }

    public GameMapChangeOrientationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
        writer.WriteInt8(Direction);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadInt32();
        Direction = reader.ReadInt8();
    }
}