namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameContextRemoveMultipleElementsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 252;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<int> Id { get; set; }

    public GameContextRemoveMultipleElementsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var idBefore = writer.Position;
        var idCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Id)
        {
            writer.WriteInt32(item);
            idCount++;
        }

        var idAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, idBefore);
        writer.WriteInt16((short)idCount);
        writer.Seek(SeekOrigin.Begin, idAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var idCount = reader.ReadInt16();
        var id = new int[idCount];
        for (var i = 0; i < idCount; i++) id[i] = reader.ReadInt32();
        Id = id;
    }
}