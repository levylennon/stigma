namespace Stigma.Protocol.Types.Game.Look;

public sealed class SubEntity : DofusType
{
    public new const ushort ProtocolTypeId = 54;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte BindingPointCategory { get; set; }

    public sbyte BindingPointIndex { get; set; }

    public EntityLook SubEntityLook { get; set; }

    public SubEntity()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(BindingPointCategory);
        writer.WriteInt8(BindingPointIndex);
        SubEntityLook.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        BindingPointCategory = reader.ReadInt8();
        BindingPointIndex = reader.ReadInt8();
        SubEntityLook = new EntityLook();
        SubEntityLook.Deserialize(reader);
    }
}