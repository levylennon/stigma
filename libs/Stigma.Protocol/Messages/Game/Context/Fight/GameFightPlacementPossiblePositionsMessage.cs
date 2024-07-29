namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightPlacementPossiblePositionsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 703;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<short> PositionsForChallengers { get; set; }

    public required IEnumerable<short> PositionsForDefenders { get; set; }

    public required sbyte TeamNumber { get; set; }

    public GameFightPlacementPossiblePositionsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var positionsForChallengersBefore = writer.Position;
        var positionsForChallengersCount = 0;
        writer.WriteInt16(0);
        foreach (var item in PositionsForChallengers)
        {
            writer.WriteInt16(item);
            positionsForChallengersCount++;
        }

        var positionsForChallengersAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, positionsForChallengersBefore);
        writer.WriteInt16((short)positionsForChallengersCount);
        writer.Seek(SeekOrigin.Begin, positionsForChallengersAfter);
        var positionsForDefendersBefore = writer.Position;
        var positionsForDefendersCount = 0;
        writer.WriteInt16(0);
        foreach (var item in PositionsForDefenders)
        {
            writer.WriteInt16(item);
            positionsForDefendersCount++;
        }

        var positionsForDefendersAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, positionsForDefendersBefore);
        writer.WriteInt16((short)positionsForDefendersCount);
        writer.Seek(SeekOrigin.Begin, positionsForDefendersAfter);
        writer.WriteInt8(TeamNumber);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var positionsForChallengersCount = reader.ReadInt16();
        var positionsForChallengers = new short[positionsForChallengersCount];
        for (var i = 0; i < positionsForChallengersCount; i++) positionsForChallengers[i] = reader.ReadInt16();
        PositionsForChallengers = positionsForChallengers;
        var positionsForDefendersCount = reader.ReadInt16();
        var positionsForDefenders = new short[positionsForDefendersCount];
        for (var i = 0; i < positionsForDefendersCount; i++) positionsForDefenders[i] = reader.ReadInt16();
        PositionsForDefenders = positionsForDefenders;
        TeamNumber = reader.ReadInt8();
    }
}