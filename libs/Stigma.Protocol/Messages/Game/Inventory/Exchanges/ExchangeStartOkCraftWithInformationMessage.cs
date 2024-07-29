namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeStartOkCraftWithInformationMessage : ExchangeStartOkCraftMessage
{
    public new const uint ProtocolMessageId = 5941;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte NbCase { get; set; }

    public required int SkillId { get; set; }

    public ExchangeStartOkCraftWithInformationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt8(NbCase);
        writer.WriteInt32(SkillId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        NbCase = reader.ReadInt8();
        SkillId = reader.ReadInt32();
    }
}