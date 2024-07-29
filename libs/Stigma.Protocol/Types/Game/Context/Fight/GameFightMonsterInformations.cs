namespace Stigma.Protocol.Types.Game.Context.Fight;

public class GameFightMonsterInformations : GameFightAIInformations
{
    public new const ushort ProtocolTypeId = 29;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short CreatureGenericId { get; set; }

    public sbyte CreatureGrade { get; set; }

    public GameFightMonsterInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(CreatureGenericId);
        writer.WriteInt8(CreatureGrade);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        CreatureGenericId = reader.ReadInt16();
        CreatureGrade = reader.ReadInt8();
    }
}