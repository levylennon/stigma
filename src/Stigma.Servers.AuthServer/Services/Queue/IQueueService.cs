using Stigma.Servers.AuthServer.Network.Transport;

namespace Stigma.Servers.AuthServer.Services.Queue;

public interface IQueueService
{
    void Enqueue(AuthSession session);
}