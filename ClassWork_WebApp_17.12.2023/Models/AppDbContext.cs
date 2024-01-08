using Microsoft.EntityFrameworkCore;

namespace ClassWork_WebApp_17._12._2023.Models
{
	public class AppDbContext : DbContext
	{

		public DbSet<Product> Products { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			//Database.EnsureCreated();
		}



	}
}
