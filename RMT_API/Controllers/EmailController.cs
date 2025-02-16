using Microsoft.AspNetCore.Mvc;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmailController(IEmailService _emailService) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> SendEmail()
		{
			string recipientEmail = "devanjan.nanda@algoleap.com";
			string subject = "Test Email from .NET Core API";
			string body = "<h1>This is a test email</h1><p>Sent via SMTP server.</p>";

			await _emailService.SendEmailAsync(recipientEmail, subject, body);

			return Ok("Email sent.");
		}
	}
}
