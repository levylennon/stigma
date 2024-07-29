namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public sealed class GameRolePlayNpcInformations : GameRolePlayActorInformations
{
    public new const ushort ProtocolTypeId = 156;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short NpcId { get; set; }

    public bool Sex { get; set; }

    public short SpecialArtworkId { get; set; }

    public bool CanGiveQuest { get; set; }

    public GameRolePlayNpcInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(NpcId);
        writer.WriteBoolean(Sex);
        writer.WriteInt16(SpecialArtworkId);
        writer.WriteBoolean(CanGiveQuest);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        NpcId = reader.ReadInt16();
        Sex = reader.ReadBoolean();
        SpecialArtworkId = reader.ReadInt16();
        CanGiveQuest = reader.ReadBoolean();
    }
}