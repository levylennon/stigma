using Stigma.Protocol.Types.Game.Character;

namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismFightAttackerAddMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5893;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double FightId { get; set; }

    public required IEnumerable<CharacterMinimalPlusLookAndGradeInformations> CharactersDescription { get; set; }

    public PrismFightAttackerAddMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(FightId);
        var charactersDescriptionBefore = writer.Position;
        var charactersDescriptionCount = 0;
        writer.WriteInt16(0);
        foreach (var item in CharactersDescription)
        {
            item.Serialize(writer);
            charactersDescriptionCount++;
        }

        var charactersDescriptionAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, charactersDescriptionBefore);
        writer.WriteInt16((short)charactersDescriptionCount);
        writer.Seek(SeekOrigin.Begin, charactersDescriptionAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadDouble();
        var charactersDescriptionCount = reader.ReadInt16();
        var charactersDescription = new CharacterMinimalPlusLookAndGradeInformations[charactersDescriptionCount];
        for (var i = 0; i < charactersDescriptionCount; i++)
        {
            var entry = new CharacterMinimalPlusLookAndGradeInformations();
            entry.Deserialize(reader);
            charactersDescription[i] = entry;
        }

        CharactersDescription = charactersDescription;
    }
}