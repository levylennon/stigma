namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public sealed class NpcStaticInformations : DofusType
{
    public new const ushort ProtocolTypeId = 155;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short NpcId { get; set; }

    public bool Sex { get; set; }

    public short SpecialArtworkId { get; set; }

    public NpcStaticInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(NpcId);
        writer.WriteBoolean(Sex);
        writer.WriteInt16(SpecialArtworkId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        NpcId = reader.ReadInt16();
        Sex = reader.ReadBoolean();
        SpecialArtworkId = reader.ReadInt16();
    }
}