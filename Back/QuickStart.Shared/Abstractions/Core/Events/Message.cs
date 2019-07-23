using System;
using MediatR;

namespace QuickStart.Shared.Abstractions.Core.Events
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