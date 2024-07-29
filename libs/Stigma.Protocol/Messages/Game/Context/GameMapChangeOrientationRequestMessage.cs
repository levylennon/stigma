namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameMapChangeOrientationRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 945;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Direction { get; set; }

    public GameMapChangeOrientationRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Direction);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Direction = reader.ReadInt8();
    }
}