namespace Stigma.Protocol.Messages.Game.Basic;

public sealed class BasicWhoIsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 180;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Self { get; set; }

    public required sbyte Position { get; set; }

    public required string AccountNickname { get; set; }

    public required string CharacterName { get; set; }

    public required short AreaId { get; set; }

    public BasicWhoIsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Self);
        writer.WriteInt8(Position);
        writer.WriteUtf(AccountNickname);
        writer.WriteUtf(CharacterName);
        writer.WriteInt16(AreaId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Self = reader.ReadBoolean();
        Position = reader.ReadInt8();
        AccountNickname = reader.ReadUtf();
        CharacterName = reader.ReadUtf();
        AreaId = reader.ReadInt16();
    }
}