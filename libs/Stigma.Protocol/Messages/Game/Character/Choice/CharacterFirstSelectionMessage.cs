namespace Stigma.Protocol.Messages.Game.Character.Choice;

public sealed class CharacterFirstSelectionMessage : CharacterSelectionMessage
{
    public new const uint ProtocolMessageId = 6084;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool DoTutorial { get; set; }

    public CharacterFirstSelectionMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteBoolean(DoTutorial);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        DoTutorial = reader.ReadBoolean();
    }
}