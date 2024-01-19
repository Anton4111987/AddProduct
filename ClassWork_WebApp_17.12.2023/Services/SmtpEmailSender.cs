using ClassWork_WebApp_17._12._2023.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ClassWork_WebApp_17._12._2023.Services
{
    public class SmtpEmailSender: IEmailSender
    {
        public SendEmailDataModel? SendEmailDataModel { get; set; }
        public readonly SmtpConfig _smtpConfig;
       
        public SmtpEmailSender(IOptions<SmtpConfig> options)
        {
            _smtpConfig = options.Value;
        }
        public async Task SendEmail(SendEmailDataModel message)
        {			
			using var emailMessage = new MimeMessage();
           
            emailMessage.From.Add(new MailboxAddress("LarionovAdministration", _smtpConfig.UserName));
            emailMessage.To.Add(new MailboxAddress("", message.Email));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = message.StringMessage
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpConfig.Host, _smtpConfig.Port, false);
				await client.AuthenticateAsync(_smtpConfig.UserName, _smtpConfig.Password);

				await client.SendAsync(emailMessage);

				await client.DisconnectAsync(true);
            }
            
        }
       
	}
}

