namespace Stigma.Protocol.Messages.Game.Character.Choice;

public sealed class CharacterSelectedForceReadyMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6072;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public CharacterSelectedForceReadyMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}