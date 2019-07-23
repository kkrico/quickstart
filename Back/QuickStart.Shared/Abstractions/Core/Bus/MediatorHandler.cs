using System.Threading.Tasks;
using MediatR;
using QuickStart.Shared.Abstractions.Core.Events;

namespace QuickStart.Shared.Abstractions.Core.Bus
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}