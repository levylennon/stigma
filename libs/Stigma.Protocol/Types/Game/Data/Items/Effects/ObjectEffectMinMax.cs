namespace Stigma.Protocol.Types.Game.Data.Items.Effects;

public sealed class ObjectEffectMinMax : ObjectEffect
{
    public new const ushort ProtocolTypeId = 82;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short Min { get; set; }

    public short Max { get; set; }

    public ObjectEffectMinMax()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(Min);
        writer.WriteInt16(Max);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Min = reader.ReadInt16();
        Max = reader.ReadInt16();
    }
}