namespace Stigma.Protocol.Types.Game.Context.Roleplay.Party;

public sealed class PartyUpdateCommonsInformations : DofusType
{
    public new const ushort ProtocolTypeId = 213;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int LifePoints { get; set; }

    public int MaxLifePoints { get; set; }

    public short Prospecting { get; set; }

    public byte RegenRate { get; set; }

    public PartyUpdateCommonsInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(LifePoints);
        writer.WriteInt32(MaxLifePoints);
        writer.WriteInt16(Prospecting);
        writer.WriteUInt8(RegenRate);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        LifePoints = reader.ReadInt32();
        MaxLifePoints = reader.ReadInt32();
        Prospecting = reader.ReadInt16();
        RegenRate = reader.ReadUInt8();
    }
}