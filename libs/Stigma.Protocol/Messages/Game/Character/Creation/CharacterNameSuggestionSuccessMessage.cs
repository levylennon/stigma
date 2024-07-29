namespace Stigma.Protocol.Messages.Game.Character.Creation;

public sealed class CharacterNameSuggestionSuccessMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5544;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Suggestion { get; set; }

    public CharacterNameSuggestionSuccessMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Suggestion);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Suggestion = reader.ReadUtf();
    }
}