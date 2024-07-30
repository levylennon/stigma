using System.Collections.Concurrent;
using Coravel.Scheduling.Schedule.Interfaces;
using Stigma.Protocol.Messages.Connection;
using Stigma.Protocol.Messages.Handshake;
using Stigma.Protocol.Messages.Queues;
using Stigma.Servers.AuthServer.Network.Transport;

namespace Stigma.Servers.AuthServer.Services.Queue;

public sealed class QueueService : IQueueService
{
    private readonly ConcurrentQueue<AuthSession> _sessions;
    
    public QueueService(IScheduler scheduler)
    {
        _sessions = [];
        scheduler.ScheduleAsync(ProcessQueueAsync).EverySeconds(2);
    }
    
    public void Enqueue(AuthSession session)
    {
        _sessions.Enqueue(session);
    }

    private async Task ProcessQueueAsync()
    {
        while (_sessions.TryDequeue(out var session))
        {
            if (!_sessions.IsEmpty)
            {
                ushort position = 0;

                foreach (var otherSession in _sessions)
                {
                    position++;
                    await otherSession.SendAsync(new LoginQueueStatusMessage
                    {
                        Position = position,
                        Total = (ushort)_sessions.Count
                    });
                }
            }

            await session.SendAsync(new ProtocolRequired
            {
                RequiredVersion = 1165,
                CurrentVersion = 1165
            });
            
            await session.SendAsync(new HelloConnectMessage
            {
                Key = session.Ticket
            });
        }
    }
}