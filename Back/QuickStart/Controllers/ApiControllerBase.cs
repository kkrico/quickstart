using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickStart.Core.Domain.Core.NotificationHandler;
using QuickStart.Shared.Abstractions.Core.Notifications;

namespace QuickStart.Web.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;

        protected ApiControllerBase(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler) notifications;
        }

        private bool IsValidOperation()
        {
            return !_notifications.HasNotifications();
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
                return Ok(new
                {
                    success = true,
                    data = result
                });

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }
    }
}