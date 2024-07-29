using Stigma.Protocol.Types.Connection;

namespace Stigma.Protocol.Messages.Connection;

public sealed class ServerStatusUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 50;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required GameServerInformations Server { get; set; }

    public ServerStatusUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        Server.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Server = new GameServerInformations();
        Server.Deserialize(reader);
    }
}