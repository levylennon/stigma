using Stigma.Protocol.Types.Game.Friend;

namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class IgnoredAddedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5678;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IgnoredInformations IgnoreAdded { get; set; }

    public IgnoredAddedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(IgnoreAdded.ProtocolId);
        IgnoreAdded.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        IgnoreAdded = DofusTypeFactory.CreateInstance<IgnoredInformations>(reader.ReadUInt16());
        IgnoreAdded.Deserialize(reader);
    }
}