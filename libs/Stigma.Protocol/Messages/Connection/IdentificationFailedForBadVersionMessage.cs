using Version = Stigma.Protocol.Types.Version.Version;

namespace Stigma.Protocol.Messages.Connection;

public sealed class IdentificationFailedForBadVersionMessage : IdentificationFailedMessage
{
    public new const uint ProtocolMessageId = 21;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required Version RequiredVersion { get; set; }

    public IdentificationFailedForBadVersionMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        RequiredVersion.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        RequiredVersion = new Version();
        RequiredVersion.Deserialize(reader);
    }
}