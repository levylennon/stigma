namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Lockable;

public sealed class LockableShowCodeDialogMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5740;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool ChangeOrUse { get; set; }

    public required sbyte CodeSize { get; set; }

    public LockableShowCodeDialogMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(ChangeOrUse);
        writer.WriteInt8(CodeSize);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ChangeOrUse = reader.ReadBoolean();
        CodeSize = reader.ReadInt8();
    }
}