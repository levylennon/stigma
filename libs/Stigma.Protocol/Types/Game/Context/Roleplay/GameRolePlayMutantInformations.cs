namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public sealed class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
{
    public new const ushort ProtocolTypeId = 3;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte PowerLevel { get; set; }

    public GameRolePlayMutantInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt8(PowerLevel);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        PowerLevel = reader.ReadInt8();
    }
}