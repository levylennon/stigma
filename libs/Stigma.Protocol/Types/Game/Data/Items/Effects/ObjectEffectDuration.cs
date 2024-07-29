namespace Stigma.Protocol.Types.Game.Data.Items.Effects;

public sealed class ObjectEffectDuration : ObjectEffect
{
    public new const ushort ProtocolTypeId = 75;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short Days { get; set; }

    public short Hours { get; set; }

    public short Minutes { get; set; }

    public ObjectEffectDuration()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(Days);
        writer.WriteInt16(Hours);
        writer.WriteInt16(Minutes);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Days = reader.ReadInt16();
        Hours = reader.ReadInt16();
        Minutes = reader.ReadInt16();
    }
}