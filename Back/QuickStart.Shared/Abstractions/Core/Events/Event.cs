using System;
using MediatR;

namespace QuickStart.Shared.Abstractions.Core.Events
{
    public abstract class Event : Message, INotification
    {
        protected Event()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; }
    }
}