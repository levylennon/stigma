namespace Stigma.Protocol.Messages.Game.Character.Choice;

public sealed class CharactersListErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5545;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public CharactersListErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}