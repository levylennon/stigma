namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismFightStateUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6040;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte State { get; set; }

    public PrismFightStateUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(State);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        State = reader.ReadInt8();
    }
}