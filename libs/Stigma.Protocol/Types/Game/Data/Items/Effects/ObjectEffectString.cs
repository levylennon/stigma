namespace Stigma.Protocol.Types.Game.Data.Items.Effects;

public sealed class ObjectEffectString : ObjectEffect
{
    public new const ushort ProtocolTypeId = 74;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string Value { get; set; }

    public ObjectEffectString()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUtf(Value);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Value = reader.ReadUtf();
    }
}