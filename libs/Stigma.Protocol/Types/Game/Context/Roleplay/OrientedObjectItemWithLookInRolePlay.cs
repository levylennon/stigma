namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public sealed class OrientedObjectItemWithLookInRolePlay : ObjectItemWithLookInRolePlay
{
    public new const ushort ProtocolTypeId = 199;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte Direction { get; set; }

    public OrientedObjectItemWithLookInRolePlay()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt8(Direction);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Direction = reader.ReadInt8();
    }
}