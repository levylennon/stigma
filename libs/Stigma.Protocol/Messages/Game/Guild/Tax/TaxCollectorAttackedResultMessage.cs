using Stigma.Protocol.Types.Game.Guild.Tax;

namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class TaxCollectorAttackedResultMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5635;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool DeadOrAlive { get; set; }

    public required TaxCollectorBasicInformations BasicInfos { get; set; }

    public TaxCollectorAttackedResultMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(DeadOrAlive);
        BasicInfos.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        DeadOrAlive = reader.ReadBoolean();
        BasicInfos = new TaxCollectorBasicInformations();
        BasicInfos.Deserialize(reader);
    }
}