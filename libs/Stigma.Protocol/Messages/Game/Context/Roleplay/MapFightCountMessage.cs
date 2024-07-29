namespace Stigma.Protocol.Messages.Game.Context.Roleplay;

public sealed class MapFightCountMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 210;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short FightCount { get; set; }

    public MapFightCountMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(FightCount);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightCount = reader.ReadInt16();
    }
}