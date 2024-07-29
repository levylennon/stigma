namespace Stigma.Protocol.Messages.Game.Basic;

public sealed class BasicSwitchModeRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6101;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Mode { get; set; }

    public BasicSwitchModeRequestMessage()
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