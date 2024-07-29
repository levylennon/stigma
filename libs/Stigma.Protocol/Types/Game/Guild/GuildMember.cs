using Stigma.Protocol.Types.Game.Character;

namespace Stigma.Protocol.Types.Game.Guild;

public sealed class GuildMember : CharacterMinimalInformations
{
    public new const ushort ProtocolTypeId = 88;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public short Rank { get; set; }

    public double GivenExperience { get; set; }

    public sbyte ExperienceGivenPercent { get; set; }

    public uint Rights { get; set; }

    public sbyte Connected { get; set; }

    public sbyte AlignmentSide { get; set; }

    public ushort HoursSinceLastConnection { get; set; }

    public GuildMember()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt8(Breed);
        writer.WriteBoolean(Sex);
        writer.WriteInt16(Rank);
        writer.WriteDouble(GivenExperience);
        writer.WriteInt8(ExperienceGivenPercent);
        writer.WriteUInt32(Rights);
        writer.WriteInt8(Connected);
        writer.WriteInt8(AlignmentSide);
        writer.WriteUInt16(HoursSinceLastConnection);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Breed = reader.ReadInt8();
        Sex = reader.ReadBoolean();
        Rank = reader.ReadInt16();
        GivenExperience = reader.ReadDouble();
        ExperienceGivenPercent = reader.ReadInt8();
        Rights = reader.ReadUInt32();
        Connected = reader.ReadInt8();
        AlignmentSide = reader.ReadInt8();
        HoursSinceLastConnection = reader.ReadUInt16();
    }
}