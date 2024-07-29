namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Npc;

public sealed class NpcGenericActionFailureMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5900;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public NpcGenericActionFailureMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}