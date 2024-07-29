namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public class GameRolePlayMerchantInformations : GameRolePlayNamedActorInformations
{
    public new const ushort ProtocolTypeId = 129;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int SellType { get; set; }

    public GameRolePlayMerchantInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(SellType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        SellType = reader.ReadInt32();
    }
}