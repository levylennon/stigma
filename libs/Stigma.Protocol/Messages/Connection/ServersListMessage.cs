using Stigma.Protocol.Types.Connection;

namespace Stigma.Protocol.Messages.Connection;

public sealed class ServersListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 30;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<GameServerInformations> Servers { get; set; }

    public ServersListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var serversBefore = writer.Position;
        var serversCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Servers)
        {
            item.Serialize(writer);
            serversCount++;
        }

        var serversAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, serversBefore);
        writer.WriteInt16((short)serversCount);
        writer.Seek(SeekOrigin.Begin, serversAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var serversCount = reader.ReadInt16();
        var servers = new GameServerInformations[serversCount];
        for (var i = 0; i < serversCount; i++)
        {
            var entry = new GameServerInformations();
            entry.Deserialize(reader);
            servers[i] = entry;
        }

        Servers = servers;
    }
}