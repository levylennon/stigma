using Stigma.Protocol.Types.Game.Mount;

namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountSetMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5968;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required MountClientData MountData { get; set; }

    public MountSetMessage()
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