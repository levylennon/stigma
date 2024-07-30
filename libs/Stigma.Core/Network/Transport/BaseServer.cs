using System.Net.Sockets;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;
using Stigma.Core.Network.Dispatcher;
using Stigma.Core.Network.Framing;
using Stigma.Core.Network.Options;

namespace Stigma.Core.Network.Transport;

public abstract class BaseServer<TSession> : IHostedService
    where TSession : BaseSession
{
    private readonly Socket _socket;
    private readonly CancellationTokenSource _cts;
    private readonly IMessageParser _messageParser;
    private readonly IMessageDispatcher _messageDispatcher;
    private readonly ServerOptions _options;
    
    protected BaseServer(IMessageParser messageParser, IMessageDispatcher messageDispatcher, IOptions<ServerOptions> options)
    {
        _messageParser = messageParser;
        _messageDispatcher = messageDispatcher;
        _options = options.Value;
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        {
            NoDelay = true,
            ReceiveTimeout = 5000,
            SendTimeout = 5000,
            LingerState = new LingerOption(true, 0)
        };
        _cts = new CancellationTokenSource();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _socket.Bind(_options.EndPoint);
        _socket.Listen();
        
        Log.Logger.Information("Server listening on: {EndPoint}", _options.EndPoint);

        while (!_cts.IsCancellationRequested)
        {
            var socket = await _socket.AcceptAsync(_cts.Token);
            
            var session = CreateSession(socket, _messageParser, _messageDispatcher);
            
            await OnSessionConnectedAsync(session);

            _ = session
                .ListenAsync()
                .ContinueWith(_ => OnSessionDisconnectedAsync(session), _cts.Token)
                .Unwrap();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        if (_cts.IsCancellationRequested)
            return Task.CompletedTask;
        
        _cts.Cancel();

        try
        {
            _socket.Shutdown(SocketShutdown.Both);
        }
        catch (SocketException)
        {
            // ignored
        }
        
        _socket.Close();
        _socket.Dispose();
        _cts.Dispose();
        
        return Task.CompletedTask;
    }

    protected abstract TSession CreateSession(Socket socket, IMessageParser messageParser, IMessageDispatcher messageDispatcher);

    protected virtual Task OnSessionConnectedAsync(TSession session)
    {
        Log.Logger.Information("Session connected: {SessionName}", session);
        
        return Task.CompletedTask;
    }
    
    protected virtual Task OnSessionDisconnectedAsync(TSession session)
    {
        Log.Logger.Information("Session disconnected: {SessionName}", session);
        
        return Task.CompletedTask;
    }
}