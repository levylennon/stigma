namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangePlayerMultiCraftRequestMessage : ExchangeRequestMessage
{
    public new const uint ProtocolMessageId = 5784;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Target { get; set; }

    public required int SkillId { get; set; }

    public ExchangePlayerMultiCraftRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(Target);
        writer.WriteInt32(SkillId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Target = reader.ReadInt32();
        SkillId = reader.ReadInt32();
    }
}