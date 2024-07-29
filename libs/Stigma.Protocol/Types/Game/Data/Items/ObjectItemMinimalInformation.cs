using Stigma.Protocol.Types.Game.Data.Items.Effects;

namespace Stigma.Protocol.Types.Game.Data.Items;

public class ObjectItemMinimalInformation : Item
{
    public new const ushort ProtocolTypeId = 124;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short ObjectGID { get; set; }

    public IEnumerable<ObjectEffect> Effects { get; set; }

    public ObjectItemMinimalInformation()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(ObjectGID);
        var effectsBefore = writer.Position;
        var effectsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Effects)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            effectsCount++;
        }

        var effectsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, effectsBefore);
        writer.WriteInt16((short)effectsCount);
        writer.Seek(SeekOrigin.Begin, effectsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        ObjectGID = reader.ReadInt16();
        var effectsCount = reader.ReadInt16();
        var effects = new ObjectEffect[effectsCount];
        for (var i = 0; i < effectsCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<ObjectEffect>(reader.ReadUInt16());
            entry.Deserialize(reader);
            effects[i] = entry;
        }

        Effects = effects;
    }
}