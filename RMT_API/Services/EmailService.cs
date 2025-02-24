using System.Net.Mail;
using System.Net;

namespace RMT_API.Services
{
	public class EmailService :IEmailService
	{

		private string _smtpServer = "smtp.office365.com";  // Change to your SMTP server (e.g., Gmail's server is smtp.gmail.com)
		private int _smtpPort = 587;  // 587 for TLS, 465 for SSL
		private string _username = "prasadd@sadhus.onmicrosoft.com";
		private string _password = "Password@11";


		public async Task SendEmailAsync(string toEmail, string subject, string body)
		{
			var fromAddress = new MailAddress(_username, "Prasad Imandi");
			var toAddress = new MailAddress(toEmail);
			var smtpClient = new SmtpClient(_smtpServer)
			{
				Port = _smtpPort,
				Credentials = new NetworkCredential(_username, _password),
				EnableSsl = true
			};

			var mailMessage = new MailMessage(fromAddress, toAddress)
			{
				Subject = subject,
				Body = body,
				IsBodyHtml = true  // Set to true if sending HTML email
			};

			try
			{
				await smtpClient.SendMailAsync(mailMessage);
				Console.WriteLine("Email sent successfully!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error sending email: {ex.Message}");
			}
		}
	}
}
