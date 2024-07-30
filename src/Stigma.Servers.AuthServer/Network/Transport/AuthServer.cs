using System.Net.Sockets;
using Microsoft.Extensions.Options;
using Stigma.Core.Network.Dispatcher;
using Stigma.Core.Network.Framing;
using Stigma.Core.Network.Options;
using Stigma.Core.Network.Transport;

namespace Stigma.Servers.AuthServer.Network.Transport;

public sealed class AuthServer : BaseServer<AuthSession>
{
    public AuthServer(IMessageParser messageParser, IMessageDispatcher messageDispatcher, IOptions<ServerOptions> options) : base(messageParser, messageDispatcher, options)
    {
    }

    protected override AuthSession CreateSession(Socket socket, IMessageParser messageParser, IMessageDispatcher messageDispatcher)
    {
        return new AuthSession(socket, messageParser, messageDispatcher);
    }
}