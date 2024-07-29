namespace Stigma.Protocol.Messages.Game.Chat.Channel;

public sealed class ChannelEnablingChangeMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 891;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Channel { get; set; }

    public required bool Enable { get; set; }

    public ChannelEnablingChangeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Channel);
        writer.WriteBoolean(Enable);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Channel = reader.ReadInt8();
        Enable = reader.ReadBoolean();
    }
}