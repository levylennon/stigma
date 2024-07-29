namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Npc;

public sealed class EntityTalkMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6110;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int EntityId { get; set; }

    public required short TextId { get; set; }

    public required IEnumerable<string> Parameters { get; set; }

    public EntityTalkMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(EntityId);
        writer.WriteInt16(TextId);
        var parametersBefore = writer.Position;
        var parametersCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Parameters)
        {
            writer.WriteUtf(item);
            parametersCount++;
        }

        var parametersAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, parametersBefore);
        writer.WriteInt16((short)parametersCount);
        writer.Seek(SeekOrigin.Begin, parametersAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        EntityId = reader.ReadInt32();
        TextId = reader.ReadInt16();
        var parametersCount = reader.ReadInt16();
        var parameters = new string[parametersCount];
        for (var i = 0; i < parametersCount; i++) parameters[i] = reader.ReadUtf();
        Parameters = parameters;
    }
}