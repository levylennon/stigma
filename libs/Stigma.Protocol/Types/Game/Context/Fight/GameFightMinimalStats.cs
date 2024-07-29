namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class GameFightMinimalStats : DofusType
{
    public new const ushort ProtocolTypeId = 31;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int LifePoints { get; set; }

    public int MaxLifePoints { get; set; }

    public short ActionPoints { get; set; }

    public short MovementPoints { get; set; }

    public int Summoner { get; set; }

    public short NeutralElementResistPercent { get; set; }

    public short EarthElementResistPercent { get; set; }

    public short WaterElementResistPercent { get; set; }

    public short AirElementResistPercent { get; set; }

    public short FireElementResistPercent { get; set; }

    public short DodgePALostProbability { get; set; }

    public short DodgePMLostProbability { get; set; }

    public sbyte InvisibilityState { get; set; }

    public GameFightMinimalStats()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(LifePoints);
        writer.WriteInt32(MaxLifePoints);
        writer.WriteInt16(ActionPoints);
        writer.WriteInt16(MovementPoints);
        writer.WriteInt32(Summoner);
        writer.WriteInt16(NeutralElementResistPercent);
        writer.WriteInt16(EarthElementResistPercent);
        writer.WriteInt16(WaterElementResistPercent);
        writer.WriteInt16(AirElementResistPercent);
        writer.WriteInt16(FireElementResistPercent);
        writer.WriteInt16(DodgePALostProbability);
        writer.WriteInt16(DodgePMLostProbability);
        writer.WriteInt8(InvisibilityState);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        LifePoints = reader.ReadInt32();
        MaxLifePoints = reader.ReadInt32();
        ActionPoints = reader.ReadInt16();
        MovementPoints = reader.ReadInt16();
        Summoner = reader.ReadInt32();
        NeutralElementResistPercent = reader.ReadInt16();
        EarthElementResistPercent = reader.ReadInt16();
        WaterElementResistPercent = reader.ReadInt16();
        AirElementResistPercent = reader.ReadInt16();
        FireElementResistPercent = reader.ReadInt16();
        DodgePALostProbability = reader.ReadInt16();
        DodgePMLostProbability = reader.ReadInt16();
        InvisibilityState = reader.ReadInt8();
    }
}