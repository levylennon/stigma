using Stigma.Protocol.Types.Game.Character.Choice;

namespace Stigma.Protocol.Messages.Game.Character.Choice;

public sealed class CharactersListWithModificationsMessage : CharactersListMessage
{
    public new const uint ProtocolMessageId = 6120;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<CharacterToRecolorInformation> CharactersToRecolor { get; set; }

    public required IEnumerable<int> CharactersToRename { get; set; }

    public CharactersListWithModificationsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        var charactersToRecolorBefore = writer.Position;
        var charactersToRecolorCount = 0;
        writer.WriteInt16(0);
        foreach (var item in CharactersToRecolor)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            charactersToRecolorCount++;
        }

        var charactersToRecolorAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, charactersToRecolorBefore);
        writer.WriteInt16((short)charactersToRecolorCount);
        writer.Seek(SeekOrigin.Begin, charactersToRecolorAfter);
        var charactersToRenameBefore = writer.Position;
        var charactersToRenameCount = 0;
        writer.WriteInt16(0);
        foreach (var item in CharactersToRename)
        {
            writer.WriteInt32(item);
            charactersToRenameCount++;
        }

        var charactersToRenameAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, charactersToRenameBefore);
        writer.WriteInt16((short)charactersToRenameCount);
        writer.Seek(SeekOrigin.Begin, charactersToRenameAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        var charactersToRecolorCount = reader.ReadInt16();
        var charactersToRecolor = new CharacterToRecolorInformation[charactersToRecolorCount];
        for (var i = 0; i < charactersToRecolorCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<CharacterToRecolorInformation>(reader.ReadUInt16());
            entry.Deserialize(reader);
            charactersToRecolor[i] = entry;
        }

        CharactersToRecolor = charactersToRecolor;
        var charactersToRenameCount = reader.ReadInt16();
        var charactersToRename = new int[charactersToRenameCount];
        for (var i = 0; i < charactersToRenameCount; i++) charactersToRename[i] = reader.ReadInt32();
        CharactersToRename = charactersToRename;
    }
}