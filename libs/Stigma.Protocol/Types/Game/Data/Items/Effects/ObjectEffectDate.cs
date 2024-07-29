namespace Stigma.Protocol.Types.Game.Data.Items.Effects;

public sealed class ObjectEffectDate : ObjectEffect
{
    public new const ushort ProtocolTypeId = 72;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short Year { get; set; }

    public short Month { get; set; }

    public short Day { get; set; }

    public short Hour { get; set; }

    public short Minute { get; set; }

    public ObjectEffectDate()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(Year);
        writer.WriteInt16(Month);
        writer.WriteInt16(Day);
        writer.WriteInt16(Hour);
        writer.WriteInt16(Minute);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Year = reader.ReadInt16();
        Month = reader.ReadInt16();
        Day = reader.ReadInt16();
        Hour = reader.ReadInt16();
        Minute = reader.ReadInt16();
    }
}