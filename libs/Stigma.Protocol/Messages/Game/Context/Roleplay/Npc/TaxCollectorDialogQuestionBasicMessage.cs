namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Npc;

public class TaxCollectorDialogQuestionBasicMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5619;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string GuildName { get; set; }

    public TaxCollectorDialogQuestionBasicMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(GuildName);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        GuildName = reader.ReadUtf();
    }
}