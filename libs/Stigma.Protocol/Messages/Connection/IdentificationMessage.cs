using Version = Stigma.Protocol.Types.Version.Version;

namespace Stigma.Protocol.Messages.Connection;

public class IdentificationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 4;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required Version VersionValue { get; set; }

    public required string Login { get; set; }

    public required string Password { get; set; }

    public required bool Autoconnect { get; set; }

    public IdentificationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        VersionValue.Serialize(writer);
        writer.WriteUtf(Login);
        writer.WriteUtf(Password);
        writer.WriteBoolean(Autoconnect);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        VersionValue = new Version();
        VersionValue.Deserialize(reader);
        Login = reader.ReadUtf();
        Password = reader.ReadUtf();
        Autoconnect = reader.ReadBoolean();
    }
}