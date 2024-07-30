using System.Net.Sockets;
using Stigma.Core.Extensions;
using Stigma.Core.Network.Dispatcher;
using Stigma.Core.Network.Framing;
using Stigma.Core.Network.Transport;

namespace Stigma.Servers.AuthServer.Network.Transport;

public sealed class AuthSession : BaseSession
{
    public string Ticket { get; }
    
    public AuthSession(Socket socket, IMessageParser messageParser, IMessageDispatcher messageDispatcher) : base(socket, messageParser, messageDispatcher)
    {
        Ticket = Random.Shared.NextString(32);
    }
}