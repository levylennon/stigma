using Stigma.Protocol.Types.Game.Guild.Tax;

namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class TaxCollectorMovementAddMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5917;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required TaxCollectorInformations Informations { get; set; }

    public TaxCollectorMovementAddMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(Informations.ProtocolId);
        Informations.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Informations = DofusTypeFactory.CreateInstance<TaxCollectorInformations>(reader.ReadUInt16());
        Informations.Deserialize(reader);
    }
}