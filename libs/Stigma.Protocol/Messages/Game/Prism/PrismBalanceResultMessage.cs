namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismBalanceResultMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5841;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte TotalBalanceValue { get; set; }

    public required sbyte SubAreaBalanceValue { get; set; }

    public PrismBalanceResultMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(TotalBalanceValue);
        writer.WriteInt8(SubAreaBalanceValue);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TotalBalanceValue = reader.ReadInt8();
        SubAreaBalanceValue = reader.ReadInt8();
    }
}