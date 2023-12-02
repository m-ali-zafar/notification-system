using NotificationSystem.Core.Interface;
using NotificationSystem.Core.Models;

namespace NotificationSystem.Infrastructure.NotificationChannel;

public class PushNotificationChannel : INotificationChannel
{
    public void Send(NotificationMessage message)
    {
        var pushMessage = message as PushNotificationMessage;
        // Implement Push Notification logic
    }
}
