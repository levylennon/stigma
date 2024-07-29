namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
{
    public new const ushort ProtocolTypeId = 159;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public HumanInformations HumanoidInfo { get; set; }

    public GameRolePlayHumanoidInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUInt16(HumanoidInfo.ProtocolId);
        HumanoidInfo.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        HumanoidInfo = DofusTypeFactory.CreateInstance<HumanInformations>(reader.ReadUInt16());
        HumanoidInfo.Deserialize(reader);
    }
}