namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Emote;

public sealed class EmotePlayMassiveMessage : EmotePlayAbstractMessage
{
    public new const uint ProtocolMessageId = 5691;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<int> ActorIds { get; set; }

    public EmotePlayMassiveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        var actorIdsBefore = writer.Position;
        var actorIdsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ActorIds)
        {
            writer.WriteInt32(item);
            actorIdsCount++;
        }

        var actorIdsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, actorIdsBefore);
        writer.WriteInt16((short)actorIdsCount);
        writer.Seek(SeekOrigin.Begin, actorIdsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        var actorIdsCount = reader.ReadInt16();
        var actorIds = new int[actorIdsCount];
        for (var i = 0; i < actorIdsCount; i++) actorIds[i] = reader.ReadInt32();
        ActorIds = actorIds;
    }
}