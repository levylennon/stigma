using Stigma.Protocol.Types.Game.Character.Choice;

namespace Stigma.Protocol.Messages.Game.Character.Choice;

public class CharactersListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 151;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool HasStartupActions { get; set; }

    public required bool TutorielAvailable { get; set; }

    public required IEnumerable<CharacterBaseInformations> Characters { get; set; }

    public CharactersListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, HasStartupActions);
        flag = BooleanByteWrapper.SetFlag(flag, 1, TutorielAvailable);
        writer.WriteUInt8(flag);
        var charactersBefore = writer.Position;
        var charactersCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Characters)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            charactersCount++;
        }

        var charactersAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, charactersBefore);
        writer.WriteInt16((short)charactersCount);
        writer.Seek(SeekOrigin.Begin, charactersAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var flag = reader.ReadUInt8();
        HasStartupActions = BooleanByteWrapper.GetFlag(flag, 0);
        TutorielAvailable = BooleanByteWrapper.GetFlag(flag, 1);
        var charactersCount = reader.ReadInt16();
        var characters = new CharacterBaseInformations[charactersCount];
        for (var i = 0; i < charactersCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<CharacterBaseInformations>(reader.ReadUInt16());
            entry.Deserialize(reader);
            characters[i] = entry;
        }

        Characters = characters;
    }
}