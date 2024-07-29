namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Lockable;

public sealed class LockableCodeResultMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5672;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Success { get; set; }

    public LockableCodeResultMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Success);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Success = reader.ReadBoolean();
    }
}