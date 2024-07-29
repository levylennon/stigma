using Stigma.Protocol.Types.Game.Character;

namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismFightDefendersStateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5899;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double FightId { get; set; }

    public required IEnumerable<CharacterMinimalPlusLookAndGradeInformations> MainFighters { get; set; }

    public required IEnumerable<CharacterMinimalPlusLookAndGradeInformations> ReserveFighters { get; set; }

    public PrismFightDefendersStateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(FightId);
        var mainFightersBefore = writer.Position;
        var mainFightersCount = 0;
        writer.WriteInt16(0);
        foreach (var item in MainFighters)
        {
            item.Serialize(writer);
            mainFightersCount++;
        }

        var mainFightersAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, mainFightersBefore);
        writer.WriteInt16((short)mainFightersCount);
        writer.Seek(SeekOrigin.Begin, mainFightersAfter);
        var reserveFightersBefore = writer.Position;
        var reserveFightersCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ReserveFighters)
        {
            item.Serialize(writer);
            reserveFightersCount++;
        }

        var reserveFightersAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, reserveFightersBefore);
        writer.WriteInt16((short)reserveFightersCount);
        writer.Seek(SeekOrigin.Begin, reserveFightersAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadDouble();
        var mainFightersCount = reader.ReadInt16();
        var mainFighters = new CharacterMinimalPlusLookAndGradeInformations[mainFightersCount];
        for (var i = 0; i < mainFightersCount; i++)
        {
            var entry = new CharacterMinimalPlusLookAndGradeInformations();
            entry.Deserialize(reader);
            mainFighters[i] = entry;
        }

        MainFighters = mainFighters;
        var reserveFightersCount = reader.ReadInt16();
        var reserveFighters = new CharacterMinimalPlusLookAndGradeInformations[reserveFightersCount];
        for (var i = 0; i < reserveFightersCount; i++)
        {
            var entry = new CharacterMinimalPlusLookAndGradeInformations();
            entry.Deserialize(reader);
            reserveFighters[i] = entry;
        }

        ReserveFighters = reserveFighters;
    }
}