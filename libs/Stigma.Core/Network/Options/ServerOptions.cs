using System.Net;
using System.Text.Json.Serialization;

#nullable disable

namespace Stigma.Core.Network.Options;

public sealed class ServerOptions
{
    public string IpAddress { get; set; }
    
    public int Port { get; set; }
    
    [JsonIgnore]
    public IPEndPoint EndPoint =>
        new(IPAddress.Parse(IpAddress), Port);
}