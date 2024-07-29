namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Lockable;

public class LockableChangeCodeMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5666;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Code { get; set; }

    public LockableChangeCodeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Code);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Code = reader.ReadUtf();
    }
}