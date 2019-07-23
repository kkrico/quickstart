using System;
using QuickStart.Shared.Abstractions.Core.Events;

namespace QuickStart.Shared.Abstractions.Core.Notifications
{
    public class DomainNotification : Event
    {
        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }

        public Guid DomainNotificationId { get; }
        public string Key { get; }
        public string Value { get; }
        public int Version { get; }
    }
}