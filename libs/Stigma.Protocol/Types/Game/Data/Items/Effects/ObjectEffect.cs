namespace Stigma.Protocol.Types.Game.Data.Items.Effects;

public class ObjectEffect : DofusType
{
    public new const ushort ProtocolTypeId = 76;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short ActionId { get; set; }

    public ObjectEffect()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(ActionId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ActionId = reader.ReadInt16();
    }
}