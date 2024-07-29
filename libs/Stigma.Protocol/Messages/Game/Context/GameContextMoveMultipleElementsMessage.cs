using Stigma.Protocol.Types.Game.Context;

namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameContextMoveMultipleElementsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 254;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<EntityMovementInformations> Movements { get; set; }

    public GameContextMoveMultipleElementsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var movementsBefore = writer.Position;
        var movementsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Movements)
        {
            item.Serialize(writer);
            movementsCount++;
        }

        var movementsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, movementsBefore);
        writer.WriteInt16((short)movementsCount);
        writer.Seek(SeekOrigin.Begin, movementsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var movementsCount = reader.ReadInt16();
        var movements = new EntityMovementInformations[movementsCount];
        for (var i = 0; i < movementsCount; i++)
        {
            var entry = new EntityMovementInformations();
            entry.Deserialize(reader);
            movements[i] = entry;
        }

        Movements = movements;
    }
}