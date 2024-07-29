namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Emote;

public sealed class EmoteListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5689;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<sbyte> EmoteIds { get; set; }

    public EmoteListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var emoteIdsBefore = writer.Position;
        var emoteIdsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in EmoteIds)
        {
            writer.WriteInt8(item);
            emoteIdsCount++;
        }

        var emoteIdsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, emoteIdsBefore);
        writer.WriteInt16((short)emoteIdsCount);
        writer.Seek(SeekOrigin.Begin, emoteIdsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var emoteIdsCount = reader.ReadInt16();
        var emoteIds = new sbyte[emoteIdsCount];
        for (var i = 0; i < emoteIdsCount; i++) emoteIds[i] = reader.ReadInt8();
        EmoteIds = emoteIds;
    }
}