namespace Stigma.Protocol.Types.Game.Data.Items.Effects;

public sealed class ObjectEffectInteger : ObjectEffect
{
    public new const ushort ProtocolTypeId = 70;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short Value { get; set; }

    public ObjectEffectInteger()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(Value);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Value = reader.ReadInt16();
    }
}