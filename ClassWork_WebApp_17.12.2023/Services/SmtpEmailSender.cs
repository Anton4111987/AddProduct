﻿using ClassWork_WebApp_17._12._2023.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ClassWork_WebApp_17._12._2023.Services
{
	public class SmtpEmailSender : IEmailSender, IAsyncDisposable
	{
		public SendEmailDataModel? SendEmailDataModel { get; set; }
		public readonly SmtpConfig _smtpConfig;
		private readonly SmtpClient _client = new();
		private readonly ILogger<SmtpEmailSender> _logger;

		public SmtpEmailSender(IOptions<SmtpConfig> options,  ILogger<SmtpEmailSender> logger)
		{
			_smtpConfig = options.Value;
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}
		public async Task SendEmail(SendEmailDataModel message)
		{
			_logger.LogInformation("Sending email to {Email} with subject {Subject}", message.Email, message.Subject);
			using var emailMessage = new MimeMessage();
			emailMessage.From.Add(new MailboxAddress("LarionovAdministration", _smtpConfig.UserName));
			emailMessage.To.Add(new MailboxAddress("", message.Email));
			emailMessage.Subject = message.Subject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
			{
				Text = message.StringMessage
			};

			await EnsureConnectedAndAuthed();
			await _client.SendAsync(emailMessage);
			_logger.LogInformation("Отправка {Email} с темой {Subject} прошла успешно", message.Email, message.Subject);

		}
		private async Task EnsureConnectedAndAuthed()
		{
			if (!_client.IsConnected)
			{
				await _client.ConnectAsync(_smtpConfig.Host, _smtpConfig.Port , false);
			}
			if (!_client.IsAuthenticated)
			{
				await _client.AuthenticateAsync(_smtpConfig.UserName, _smtpConfig.Password);
			}
		}

		// Вызовет DI контейнер, который вызовет DisposeAsync
		public async ValueTask DisposeAsync()
		{
			await _client.DisconnectAsync(true);
			_client.Dispose();
		}
	}
}

