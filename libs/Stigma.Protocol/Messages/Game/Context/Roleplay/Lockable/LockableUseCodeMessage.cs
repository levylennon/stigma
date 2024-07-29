namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Lockable;

public sealed class LockableUseCodeMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5667;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Code { get; set; }

    public LockableUseCodeMessage()
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