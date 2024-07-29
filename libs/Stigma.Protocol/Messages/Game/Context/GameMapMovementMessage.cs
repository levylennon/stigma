namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameMapMovementMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 951;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ActorId { get; set; }

    public required IEnumerable<short> KeyMovements { get; set; }

    public GameMapMovementMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ActorId);
        var keyMovementsBefore = writer.Position;
        var keyMovementsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in KeyMovements)
        {
            writer.WriteInt16(item);
            keyMovementsCount++;
        }

        var keyMovementsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, keyMovementsBefore);
        writer.WriteInt16((short)keyMovementsCount);
        writer.Seek(SeekOrigin.Begin, keyMovementsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ActorId = reader.ReadInt32();
        var keyMovementsCount = reader.ReadInt16();
        var keyMovements = new short[keyMovementsCount];
        for (var i = 0; i < keyMovementsCount; i++) keyMovements[i] = reader.ReadInt16();
        KeyMovements = keyMovements;
    }
}