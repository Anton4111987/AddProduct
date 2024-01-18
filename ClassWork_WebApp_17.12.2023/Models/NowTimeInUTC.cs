namespace ClassWork_WebApp_17._12._2023.Models
{
	public class NowTimeInUTC : INowTime
	{
		public DateTime DateNow { get; set; }
		public DayOfWeek DayOfWeek { get; set; }

		public NowTimeInUTC()
		{
			DateNow = DateTime.UtcNow;
			DayOfWeek = DateTime.UtcNow.DayOfWeek;
		}

	}
}
