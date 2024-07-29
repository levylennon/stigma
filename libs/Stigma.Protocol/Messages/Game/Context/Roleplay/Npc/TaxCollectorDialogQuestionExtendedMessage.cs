namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Npc;

public sealed class TaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionBasicMessage
{
    public new const uint ProtocolMessageId = 5615;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short Pods { get; set; }

    public required short Prospecting { get; set; }

    public required short Wisdom { get; set; }

    public required sbyte TaxCollectorsCount { get; set; }

    public TaxCollectorDialogQuestionExtendedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(Pods);
        writer.WriteInt16(Prospecting);
        writer.WriteInt16(Wisdom);
        writer.WriteInt8(TaxCollectorsCount);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Pods = reader.ReadInt16();
        Prospecting = reader.ReadInt16();
        Wisdom = reader.ReadInt16();
        TaxCollectorsCount = reader.ReadInt8();
    }
}