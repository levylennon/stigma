namespace Stigma.Protocol.Types.Game.Paddock;

public class PaddockAbandonnedInformations : PaddockBuyableInformations
{
    public new const ushort ProtocolTypeId = 133;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int GuildId { get; set; }

    public PaddockAbandonnedInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(GuildId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        GuildId = reader.ReadInt32();
    }
}