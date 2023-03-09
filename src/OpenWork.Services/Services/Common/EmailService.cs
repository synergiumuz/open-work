using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


using Microsoft.Extensions.Configuration;


using OpenWork.Services.Interfaces.Common;


namespace OpenWork.Services.Services.Common;

public class EmailService : IEmailService
{
	private readonly IConfiguration _config;
	public EmailService(IConfiguration configuration)
	{
		_config = configuration.GetSection("EmailConnection");
	}
	public async Task<bool> SendCodeAsync(string email, int code)
	{
		MailAddress from = new MailAddress(_config["Email"], "Open Work");
		MailAddress to = new MailAddress(email);
		MailMessage message = new MailMessage(from, to);
		message.Subject = "Verification code for Open Work";
		message.Body = $"<h2>{code}<h2>";
		message.IsBodyHtml = true;
		SmtpClient client = new SmtpClient(_config["Host"], int.Parse(_config["Port"]));
		client.EnableSsl = true;
		client.Credentials = new NetworkCredential(_config["Email"], _config["Password"]);
		await client.SendMailAsync(message);
		return true;
	}
}
