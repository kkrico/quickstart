using System.Threading.Tasks;
using QuickStart.Shared.Abstractions.Core.Events;

namespace QuickStart.Shared.Abstractions.Core.Bus
{
    public interface IMediatorHandler
    {
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}