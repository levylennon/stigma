namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public sealed class GameRolePlayMerchantWithGuildInformations : GameRolePlayMerchantInformations
{
    public new const ushort ProtocolTypeId = 146;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public GuildInformations GuildInformationsValue { get; set; }

    public GameRolePlayMerchantWithGuildInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        GuildInformationsValue.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        GuildInformationsValue = new GuildInformations();
        GuildInformationsValue.Deserialize(reader);
    }
}