using Stigma.Core.Network.Metadata;
using Stigma.Core.Network.Transport;

namespace Stigma.Core.Network.Dispatcher;

public interface IMessageDispatcher
{
    Task DispatchMessageAsync(BaseSession session, DofusMessage message);
}