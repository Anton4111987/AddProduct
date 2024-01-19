using ClassWork_WebApp_17._12._2023.Models; 
namespace ClassWork_WebApp_17._12._2023.Services
{
	public interface IEmailSender
	{
		public Task SendEmail(SendEmailDataModel model);
		
	}
}
