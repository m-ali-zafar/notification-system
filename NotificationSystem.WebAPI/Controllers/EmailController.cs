using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Core.Interface;
using NotificationSystem.Core.Models;

namespace NotificationSystem.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    private readonly INotificationChannel _emailChannel;
    private readonly ILogger<EmailController> _logger;

    public EmailController(INotificationChannel emailChannel, ILogger<EmailController> logger)
    {
        _emailChannel = emailChannel;
        _logger = logger;
    }

    /// <summary>
    /// Sends an Email message.
    /// </summary>
    /// <param name="message">The Email message details.</param>
    /// <returns>Returns a status indicating the result of the operation.</returns>
    [HttpPost]
    public IActionResult SendEmail([FromBody] EmailMessage message)
    {
        try
        {
            _emailChannel.Send(message);
            _logger.LogInformation("Email sent successfully.");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error: {ex.Message}");
            return BadRequest();
        }
    }
}
