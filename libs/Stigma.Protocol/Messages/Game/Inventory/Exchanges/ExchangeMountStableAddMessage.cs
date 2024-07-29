using Stigma.Protocol.Types.Game.Mount;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public class ExchangeMountStableAddMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5971;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required MountClientData MountDescription { get; set; }

    public ExchangeMountStableAddMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        MountDescription.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MountDescription = new MountClientData();
        MountDescription.Deserialize(reader);
    }
}