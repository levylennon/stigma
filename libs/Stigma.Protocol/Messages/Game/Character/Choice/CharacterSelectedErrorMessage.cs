namespace Stigma.Protocol.Messages.Game.Character.Choice;

public sealed class CharacterSelectedErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5836;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public CharacterSelectedErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}