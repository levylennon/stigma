using Stigma.Protocol.Types.Game.Mount;

namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountDataMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5973;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required MountClientData MountData { get; set; }

    public MountDataMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        MountData.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MountData = new MountClientData();
        MountData.Deserialize(reader);
    }
}