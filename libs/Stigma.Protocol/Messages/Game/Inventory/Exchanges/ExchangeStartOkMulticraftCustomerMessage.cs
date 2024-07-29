namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeStartOkMulticraftCustomerMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5817;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte MaxCase { get; set; }

    public required int SkillId { get; set; }

    public required sbyte CrafterJobLevel { get; set; }

    public ExchangeStartOkMulticraftCustomerMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(MaxCase);
        writer.WriteInt32(SkillId);
        writer.WriteInt8(CrafterJobLevel);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MaxCase = reader.ReadInt8();
        SkillId = reader.ReadInt32();
        CrafterJobLevel = reader.ReadInt8();
    }
}