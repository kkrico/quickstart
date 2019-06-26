using System;
using MediatR;

namespace QuickStart.Core.Domain.Core.Events
{
    public abstract class Message : IRequest
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }

        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
    }
}