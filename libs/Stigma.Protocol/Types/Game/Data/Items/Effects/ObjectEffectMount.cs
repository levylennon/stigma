namespace Stigma.Protocol.Types.Game.Data.Items.Effects;

public sealed class ObjectEffectMount : ObjectEffect
{
    public new const ushort ProtocolTypeId = 179;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int MountId { get; set; }

    public double Date { get; set; }

    public short ModelId { get; set; }

    public ObjectEffectMount()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(MountId);
        writer.WriteDouble(Date);
        writer.WriteInt16(ModelId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MountId = reader.ReadInt32();
        Date = reader.ReadDouble();
        ModelId = reader.ReadInt16();
    }
}