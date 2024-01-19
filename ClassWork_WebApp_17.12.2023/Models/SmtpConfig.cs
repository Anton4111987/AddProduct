using System.ComponentModel.DataAnnotations;

namespace ClassWork_WebApp_17._12._2023.Models
{
	public class SmtpConfig
	{
		[Required]
		public string? Host { get; set; }
		[EmailAddress]
		public string? UserName { get; set; }
		[Required]
		public string? Password { get; set; }
		[Range(1, ushort.MaxValue)]
		public int Port { get; set; }

		public void GetWithEnvironmentVariable()
		{
			string smtpServer = "smpt-сервер";
			string login = "логинДляОтправкиСообщений";
			string pass = "парольДляОтправкиСообщений";
			string port = "портДляОтправкиСообщений";

			Host = Environment.GetEnvironmentVariable(smtpServer);
			if (Host == null)
			{
				throw new InvalidOperationException($"Переменная среды окружения {smtpServer} не задана ");
			}
			UserName = Environment.GetEnvironmentVariable(login);
			if (UserName == null)
			{
				throw new InvalidOperationException($"Переменная среды окружения {login} не задана ");
			}
			Password = Environment.GetEnvironmentVariable(pass);
			if (Password == null)
			{
				throw new InvalidOperationException($"Переменная среды окружения {pass} не задана ");
			}
			string? portString = Environment.GetEnvironmentVariable(port);
			Port = Convert.ToInt32(portString);
			if (Port == null)
			{
				throw new InvalidOperationException($"Переменная среды окружения {port} не задана ");
			}


		}


	}
}
