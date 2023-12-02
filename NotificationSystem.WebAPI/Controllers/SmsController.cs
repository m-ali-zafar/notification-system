using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Core.Interface;
using NotificationSystem.Core.Models;

namespace NotificationSystem.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SMSController : ControllerBase
{
    private readonly INotificationChannel _smsChannel;
    private readonly ILogger<SMSController> _logger;

    public SMSController(INotificationChannel smsChannel, ILogger<SMSController> logger)
    {
        _smsChannel = smsChannel;
        _logger = logger;
    }

    /// <summary>
    /// Sends an SMS message.
    /// </summary>
    /// <param name="message">The SMS message details.</param>
    /// <returns>Returns a status indicating the result of the operation.</returns>
    [HttpPost]
    public IActionResult SendSMS([FromBody] SmsMessage message)
    {
        try
        {
            _smsChannel.Send(message);
            _logger.LogInformation("SMS sent successfully.");
            return Ok();
        }
        catch (Exception ex)
        {
           _logger.LogError($"Error: {ex.Message}");
            return BadRequest();
        }
    }
}
