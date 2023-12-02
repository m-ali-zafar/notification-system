using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Interface;

public interface INotificationChannel
{
    void Send(NotificationMessage message);
}
