namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Quest;

public sealed class QuestListRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5623;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public QuestListRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}