namespace Stigma.Protocol.Messages.Game.Context.Display;

public sealed class DisplayNumericalValueMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5808;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int EntityId { get; set; }

    public required int Value { get; set; }

    public required sbyte Type { get; set; }

    public DisplayNumericalValueMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(EntityId);
        writer.WriteInt32(Value);
        writer.WriteInt8(Type);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        EntityId = reader.ReadInt32();
        Value = reader.ReadInt32();
        Type = reader.ReadInt8();
    }
}