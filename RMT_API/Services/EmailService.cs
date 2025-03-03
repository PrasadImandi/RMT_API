using MailKit.Net.Smtp;
using MimeKit;

namespace RMT_API.Services
{
	public class EmailService : IEmailService
	{

		private string _smtpServer = "smtp.office365.com";  // Change to your SMTP server (e.g., Gmail's server is smtp.gmail.com)
		private int _smtpPort = 587;  // 587 for TLS, 465 for SSL
		private string _username = "prasadd@sadhus.onmicrosoft.com";
		private string _password = "London@Hitech";


		public async Task SendEmailAsync(string toEmail, string subject, string body)
		{
			var emailMessage = new MimeMessage();

			emailMessage.From.Add(new MailboxAddress("Prasad Imandi", _username));
			emailMessage.To.Add(new MailboxAddress("Imandi", "durgaprasad.imandi@algoleap.com"));
			emailMessage.Subject = "Test Email from MailKit with Office 365";
			emailMessage.Body = new TextPart("plain")
			{
				Text = "This is a test email sent using MailKit and Office 365 SMTP."
			};
			try
			{
				using (var client = new SmtpClient())
				{
					await client.ConnectAsync(_smtpServer, _smtpPort, false);  // Port 587 for TLS
					await client.AuthenticateAsync(_username, _password);
					await client.SendAsync(emailMessage);
					await client.DisconnectAsync(true);
				}
			}
			catch (Exception ex)
			{

			}
		}
	}
}
