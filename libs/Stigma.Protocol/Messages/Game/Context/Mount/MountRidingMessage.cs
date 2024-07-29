namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountRidingMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5967;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool IsRiding { get; set; }

    public MountRidingMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(IsRiding);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        IsRiding = reader.ReadBoolean();
    }
}