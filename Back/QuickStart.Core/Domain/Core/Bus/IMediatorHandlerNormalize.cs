using System.Threading.Tasks;
using QuickStart.Core.Domain.Core.Events;

namespace QuickStart.Core.Domain.Core.Bus
{
    public interface IMediatorHandlerNormalize
    {
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
