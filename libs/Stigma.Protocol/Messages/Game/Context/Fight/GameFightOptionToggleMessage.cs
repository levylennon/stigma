namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightOptionToggleMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 707;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Option { get; set; }

    public GameFightOptionToggleMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Option);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Option = reader.ReadInt8();
    }
}