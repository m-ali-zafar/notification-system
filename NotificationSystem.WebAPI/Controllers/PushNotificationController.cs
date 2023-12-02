using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Core.Interface;
using NotificationSystem.Core.Models;

namespace NotificationSystem.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PushNotificationController : ControllerBase
{
    private readonly INotificationChannel _pushNotificationChannel;
    private readonly ILogger<PushNotificationController> _logger;

    public PushNotificationController(INotificationChannel pushNotificationChannel, ILogger<PushNotificationController> logger)
    {
        _pushNotificationChannel = pushNotificationChannel;
        _logger = logger;
    }

    /// <summary>
    /// Sends an push notification.
    /// </summary>
    /// <param name="message">The push notification message details.</param>
    /// <returns>Returns a status indicating the result of the operation.</returns>
    [HttpPost]
    public IActionResult SendPushNotification([FromBody] PushNotificationMessage message)
    {
        try
        {
            _pushNotificationChannel.Send(message);
            _logger.LogInformation("Push notification sent successfully.");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error: {ex.Message}");
            return BadRequest();
        }
    }
}
