namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class GameFightTaxCollectorInformations : GameFightAIInformations
{
    public new const ushort ProtocolTypeId = 48;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short FirstNameId { get; set; }

    public short LastNameId { get; set; }

    public short Level { get; set; }

    public GameFightTaxCollectorInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(FirstNameId);
        writer.WriteInt16(LastNameId);
        writer.WriteInt16(Level);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        FirstNameId = reader.ReadInt16();
        LastNameId = reader.ReadInt16();
        Level = reader.ReadInt16();
    }
}