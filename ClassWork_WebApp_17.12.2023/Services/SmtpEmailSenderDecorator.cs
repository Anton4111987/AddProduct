using ClassWork_WebApp_17._12._2023.Models;
using MailKit;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;

namespace ClassWork_WebApp_17._12._2023.Services
{
	public class SmtpEmailSenderDecorator: SmtpEmailSender
	{
		
		protected SmtpEmailSender smtpEmailSender;
		public new readonly SmtpConfig _smtpConfig;
		public SmtpEmailSenderDecorator(SmtpEmailSender smtpEmailSender, IOptions<SmtpConfig> opt) : base(opt)
        {
			_smtpConfig = opt.Value;
			this.smtpEmailSender = smtpEmailSender;
			

		}
		
		public async void Send()
		{
			/*try
			{
				
				await smtpEmailSender.sendMessage.SendEmail(sendEmailDataModel);
				dispatchReport = $"Сообщение '{sendEmailDataModel.Subject}' успешно отправлено";
				Logger.LogInformation("Отправка имейла на адрес {Email} успешно выполнена", sendEmailDataModel.Email);
				sendEmailDataModel = new();
			}
			catch (Exception e) when (_attemptToSend < 3
								&& e is ServiceNotAuthenticatedException
								or ServiceNotConnectedException)
			{
				Logger.LogWarning(e, "Ошибка отправки емейла на адрес {Email}. Делаем еще 3 попытки", sendEmailDataModel.Email);
				await Send();
			}
			catch (Exception e)
			{
				Logger.LogCritical(e, "Ошибка отправки емейла на адрес {Email}. Ошибка: {Error}", sendEmailDataModel.Email, e.Message);
				dispatchReport = "Ошибка отправки письма ";
			}*/
		}





    }
}
