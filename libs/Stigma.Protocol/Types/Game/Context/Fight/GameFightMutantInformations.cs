namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class GameFightMutantInformations : GameFightFighterNamedInformations
{
    public new const ushort ProtocolTypeId = 50;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte PowerLevel { get; set; }

    public GameFightMutantInformations()
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