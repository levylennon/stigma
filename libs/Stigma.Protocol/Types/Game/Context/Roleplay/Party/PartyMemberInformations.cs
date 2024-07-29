using Stigma.Protocol.Types.Game.Character;

namespace Stigma.Protocol.Types.Game.Context.Roleplay.Party;

public sealed class PartyMemberInformations : CharacterMinimalPlusLookInformations
{
    public new const ushort ProtocolTypeId = 90;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int LifePoints { get; set; }

    public int MaxLifePoints { get; set; }

    public short Prospecting { get; set; }

    public byte RegenRate { get; set; }

    public short Initiative { get; set; }

    public bool PvpEnabled { get; set; }

    public sbyte AlignmentSide { get; set; }

    public PartyMemberInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(LifePoints);
        writer.WriteInt32(MaxLifePoints);
        writer.WriteInt16(Prospecting);
        writer.WriteUInt8(RegenRate);
        writer.WriteInt16(Initiative);
        writer.WriteBoolean(PvpEnabled);
        writer.WriteInt8(AlignmentSide);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        LifePoints = reader.ReadInt32();
        MaxLifePoints = reader.ReadInt32();
        Prospecting = reader.ReadInt16();
        RegenRate = reader.ReadUInt8();
        Initiative = reader.ReadInt16();
        PvpEnabled = reader.ReadBoolean();
        AlignmentSide = reader.ReadInt8();
    }
}