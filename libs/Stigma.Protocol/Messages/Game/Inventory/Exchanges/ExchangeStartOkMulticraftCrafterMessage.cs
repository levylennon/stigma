namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeStartOkMulticraftCrafterMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5818;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte MaxCase { get; set; }

    public required int SkillId { get; set; }

    public ExchangeStartOkMulticraftCrafterMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(MaxCase);
        writer.WriteInt32(SkillId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MaxCase = reader.ReadInt8();
        SkillId = reader.ReadInt32();
    }
}