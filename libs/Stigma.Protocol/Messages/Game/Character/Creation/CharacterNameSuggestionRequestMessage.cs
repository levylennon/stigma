namespace Stigma.Protocol.Messages.Game.Character.Creation;

public sealed class CharacterNameSuggestionRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 162;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public CharacterNameSuggestionRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}