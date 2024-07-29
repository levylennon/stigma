namespace Stigma.Protocol.Messages.Game.Context.Roleplay;

public sealed class MapRunningFightDetailsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5751;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int FightId { get; set; }

    public required IEnumerable<string> Names { get; set; }

    public required IEnumerable<short> Levels { get; set; }

    public required sbyte TeamSwap { get; set; }

    public required IEnumerable<bool> Alives { get; set; }

    public MapRunningFightDetailsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(FightId);
        var namesBefore = writer.Position;
        var namesCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Names)
        {
            writer.WriteUtf(item);
            namesCount++;
        }

        var namesAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, namesBefore);
        writer.WriteInt16((short)namesCount);
        writer.Seek(SeekOrigin.Begin, namesAfter);
        var levelsBefore = writer.Position;
        var levelsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Levels)
        {
            writer.WriteInt16(item);
            levelsCount++;
        }

        var levelsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, levelsBefore);
        writer.WriteInt16((short)levelsCount);
        writer.Seek(SeekOrigin.Begin, levelsAfter);
        writer.WriteInt8(TeamSwap);
        var alivesBefore = writer.Position;
        var alivesCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Alives)
        {
            writer.WriteBoolean(item);
            alivesCount++;
        }

        var alivesAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, alivesBefore);
        writer.WriteInt16((short)alivesCount);
        writer.Seek(SeekOrigin.Begin, alivesAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadInt32();
        var namesCount = reader.ReadInt16();
        var names = new string[namesCount];
        for (var i = 0; i < namesCount; i++) names[i] = reader.ReadUtf();
        Names = names;
        var levelsCount = reader.ReadInt16();
        var levels = new short[levelsCount];
        for (var i = 0; i < levelsCount; i++) levels[i] = reader.ReadInt16();
        Levels = levels;
        TeamSwap = reader.ReadInt8();
        var alivesCount = reader.ReadInt16();
        var alives = new bool[alivesCount];
        for (var i = 0; i < alivesCount; i++) alives[i] = reader.ReadBoolean();
        Alives = alives;
    }
}