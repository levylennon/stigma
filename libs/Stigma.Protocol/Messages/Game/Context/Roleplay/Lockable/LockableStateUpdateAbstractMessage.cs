namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Lockable;

public class LockableStateUpdateAbstractMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5671;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Locked { get; set; }

    public LockableStateUpdateAbstractMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Locked);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Locked = reader.ReadBoolean();
    }
}