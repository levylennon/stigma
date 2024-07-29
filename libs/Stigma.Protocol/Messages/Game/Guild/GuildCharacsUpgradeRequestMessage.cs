namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildCharacsUpgradeRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5706;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte CharaTypeTarget { get; set; }

    public GuildCharacsUpgradeRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(CharaTypeTarget);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CharaTypeTarget = reader.ReadInt8();
    }
}