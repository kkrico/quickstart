﻿using System;
using MediatR;

namespace QuickStart.Core.Domain.Core.Events
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