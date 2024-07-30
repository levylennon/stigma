using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using Serilog;
using Stigma.Core.Network.Dispatcher;
using Stigma.Core.Network.Framing;
using Stigma.Core.Network.Metadata;

namespace Stigma.Core.Network.Transport;

[DebuggerDisplay("{ToString(),nq}")]
public abstract class BaseSession : IDisposable
{
    private readonly Socket _socket;
    private readonly CancellationTokenSource _cts;
    private readonly IMessageParser _messageParser;
    private readonly IMessageDispatcher _messageDispatcher;

    public string IpAddress =>
        (_socket.RemoteEndPoint as IPEndPoint)!.Address.ToString();

    protected BaseSession(Socket socket, IMessageParser messageParser, IMessageDispatcher messageDispatcher)
    {
        _socket = socket;
        _cts = new CancellationTokenSource();
        _messageParser = messageParser;
        _messageDispatcher = messageDispatcher;
    }

    internal async Task ListenAsync()
    {
        while (_socket.Connected && !_cts.IsCancellationRequested)
        {
            var buffer = new Memory<byte>(new byte[8192]);
            
            var bytesRead = await _socket.ReceiveAsync(buffer, SocketFlags.None, _cts.Token);
            
            if (bytesRead is 0)
            {
                break;
            }

            try
            {
                while (_messageParser.TryDecodeMessage(ref buffer, out var message))
                {
                    #if DEBUG
                    Log.Logger.Information("[RCV] {MessageName} {SessionName}", message.GetType().Name, ToString());
                    #endif

                    await _messageDispatcher.DispatchMessageAsync(this, message);
                }
            }
            catch (SocketException)
            {
                break;
            }
        }
    }

    public async Task SendAsync(DofusMessage message)
    {
        if (!_socket.Connected || _cts.IsCancellationRequested)
        {
            return;
        }
        
        var buffer = _messageParser.EncodeMessage(message);
        
        await _socket.SendAsync(buffer, SocketFlags.None, _cts.Token);
        
        #if DEBUG
        Log.Logger.Information("[SND] {MessageName} {SessionName}", message.GetType().Name, ToString());
        #endif
    }

    public void Disconnect()
    {
        if (!_socket.Connected || _cts.IsCancellationRequested)
        {
            return;
        }
        
        _cts.Cancel();
    }

    public void Dispose()
    {
        if (!_cts.IsCancellationRequested)
        {
            _cts.Cancel();
        }

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
        
        GC.SuppressFinalize(this);
    }

    public override string ToString()
    {
        return IpAddress;
    }
}