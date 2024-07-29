using Stigma.Protocol.Types.Game.Character;

namespace Stigma.Protocol.Types.Game.Guild.Tax;

public sealed class TaxCollectorFightersInformation : DofusType
{
    public new const ushort ProtocolTypeId = 169;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int CollectorId { get; set; }

    public IEnumerable<CharacterMinimalPlusLookInformations> AllyCharactersInformations { get; set; }

    public IEnumerable<CharacterMinimalPlusLookInformations> EnemyCharactersInformations { get; set; }

    public TaxCollectorFightersInformation()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(CollectorId);
        var allyCharactersInformationsBefore = writer.Position;
        var allyCharactersInformationsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in AllyCharactersInformations)
        {
            item.Serialize(writer);
            allyCharactersInformationsCount++;
        }

        var allyCharactersInformationsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, allyCharactersInformationsBefore);
        writer.WriteInt16((short)allyCharactersInformationsCount);
        writer.Seek(SeekOrigin.Begin, allyCharactersInformationsAfter);
        var enemyCharactersInformationsBefore = writer.Position;
        var enemyCharactersInformationsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in EnemyCharactersInformations)
        {
            item.Serialize(writer);
            enemyCharactersInformationsCount++;
        }

        var enemyCharactersInformationsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, enemyCharactersInformationsBefore);
        writer.WriteInt16((short)enemyCharactersInformationsCount);
        writer.Seek(SeekOrigin.Begin, enemyCharactersInformationsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CollectorId = reader.ReadInt32();
        var allyCharactersInformationsCount = reader.ReadInt16();
        var allyCharactersInformations = new CharacterMinimalPlusLookInformations[allyCharactersInformationsCount];
        for (var i = 0; i < allyCharactersInformationsCount; i++)
        {
            var entry = new CharacterMinimalPlusLookInformations();
            entry.Deserialize(reader);
            allyCharactersInformations[i] = entry;
        }

        AllyCharactersInformations = allyCharactersInformations;
        var enemyCharactersInformationsCount = reader.ReadInt16();
        var enemyCharactersInformations = new CharacterMinimalPlusLookInformations[enemyCharactersInformationsCount];
        for (var i = 0; i < enemyCharactersInformationsCount; i++)
        {
            var entry = new CharacterMinimalPlusLookInformations();
            entry.Deserialize(reader);
            enemyCharactersInformations[i] = entry;
        }

        EnemyCharactersInformations = enemyCharactersInformations;
    }
}