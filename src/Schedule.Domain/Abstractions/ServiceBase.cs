using AutoMapper;
using Schedule.Domain.Notification;

namespace Schedule.Domain.Abstractions
{
    public abstract class ServiceBase
    {

        protected INotificationHandler _notificationHandler;
        public ServiceBase(INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }
    }
}