namespace Stigma.Protocol.Messages.Game.Character.Choice;

public sealed class CharacterSelectionWithRenameMessage : CharacterSelectionMessage
{
    public new const uint ProtocolMessageId = 6121;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public CharacterSelectionWithRenameMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUtf(Name);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Name = reader.ReadUtf();
    }
}