namespace Stigma.Protocol.Messages.Game.Character.Choice;

public sealed class CharactersListRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 150;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public CharactersListRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}