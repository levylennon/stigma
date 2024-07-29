using Stigma.Protocol.Types.Game.Guild.Tax;

namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class TaxCollectorMovementMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5633;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool HireOrFire { get; set; }

    public required TaxCollectorBasicInformations BasicInfos { get; set; }

    public required string PlayerName { get; set; }

    public TaxCollectorMovementMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(HireOrFire);
        BasicInfos.Serialize(writer);
        writer.WriteUtf(PlayerName);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        HireOrFire = reader.ReadBoolean();
        BasicInfos = new TaxCollectorBasicInformations();
        BasicInfos.Deserialize(reader);
        PlayerName = reader.ReadUtf();
    }
}