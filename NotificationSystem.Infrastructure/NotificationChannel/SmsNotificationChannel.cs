using NotificationSystem.Core.Interface;
using NotificationSystem.Core.Models;

namespace NotificationSystem.Infrastructure.NotificationChannel;

public class SmsNotificationChannel : INotificationChannel
{
    public void Send(NotificationMessage message)
    {
        var smsMessage = message as SmsMessage;
        // Implement SMS sending logic
    }
}
