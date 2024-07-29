namespace Stigma.Protocol.Types.Game.Data.Items.Effects;

public sealed class ObjectEffectDice : ObjectEffect
{
    public new const ushort ProtocolTypeId = 73;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short DiceNum { get; set; }

    public short DiceSide { get; set; }

    public short DiceConst { get; set; }

    public ObjectEffectDice()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(DiceNum);
        writer.WriteInt16(DiceSide);
        writer.WriteInt16(DiceConst);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        DiceNum = reader.ReadInt16();
        DiceSide = reader.ReadInt16();
        DiceConst = reader.ReadInt16();
    }
}