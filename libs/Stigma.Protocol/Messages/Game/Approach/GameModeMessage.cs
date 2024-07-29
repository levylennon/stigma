namespace Stigma.Protocol.Messages.Game.Approach;

public sealed class GameModeMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6003;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Mode { get; set; }

    public GameModeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Mode);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Mode = reader.ReadInt8();
    }
}