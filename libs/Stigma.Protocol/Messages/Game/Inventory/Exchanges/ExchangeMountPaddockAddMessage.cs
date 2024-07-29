using Stigma.Protocol.Types.Game.Mount;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeMountPaddockAddMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6049;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required MountClientData MountDescription { get; set; }

    public ExchangeMountPaddockAddMessage()
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