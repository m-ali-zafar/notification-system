using NotificationSystem.Core.Interface;
using NotificationSystem.Core.Models;

namespace NotificationSystem.Infrastructure.NotificationChannel;

public class EmailNotificationChannel : INotificationChannel
{
    public void Send(NotificationMessage message)
    {
        var emailMessage = message as EmailMessage;
        // Implement Email sending logic
    }
}
