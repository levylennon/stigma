namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public class ObjectItemInRolePlay : DofusType
{
    public new const ushort ProtocolTypeId = 198;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short CellId { get; set; }

    public short ObjectGID { get; set; }

    public ObjectItemInRolePlay()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(CellId);
        writer.WriteInt16(ObjectGID);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CellId = reader.ReadInt16();
        ObjectGID = reader.ReadInt16();
    }
}