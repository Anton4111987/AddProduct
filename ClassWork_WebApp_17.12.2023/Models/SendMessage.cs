using MailKit.Net.Smtp;
using MimeKit;

namespace ClassWork_WebApp_17._12._2023.Models
{	
	public class SendMessage
	{
		public Message? Message { get; set; }

		readonly string smtpServer = "smpt-сервер";
		readonly string login = "логинДляОтправкиСообщений";
		readonly string pass = "парольДляОтправкиСообщений";

        public void  SendEmail(Message message)
		{
			string? tokenSmtpServer = Environment.GetEnvironmentVariable(smtpServer);
			if (tokenSmtpServer == null)
			{
				throw new InvalidOperationException($"Переменная среды окружения {smtpServer} не задана ");
			}
			string? tokenlogin = Environment.GetEnvironmentVariable(login);
			if (tokenlogin == null)
			{
				throw new InvalidOperationException($"Переменная среды окружения {login} не задана ");
			}
			string? tokenpass = Environment.GetEnvironmentVariable(pass);
			if (tokenpass == null)
			{
				throw new InvalidOperationException($"Переменная среды окружения {pass} не задана ");
			}

			using var emailMessage = new MimeMessage();

			emailMessage.From.Add(new MailboxAddress("LarionovAdministration", tokenlogin));
			emailMessage.To.Add(new MailboxAddress("", message.Email));
			emailMessage.Subject = message.Subject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
			{
				Text = message.StringMessage
            };

			using (var client = new SmtpClient())
			{

				client.Connect(tokenSmtpServer, 25, false);
				client.Authenticate(tokenlogin, tokenpass);
				
				client.Send(emailMessage);

				client.Disconnect(true);
			}
		}

	}
}
