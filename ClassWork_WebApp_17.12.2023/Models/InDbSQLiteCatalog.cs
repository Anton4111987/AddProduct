using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace ClassWork_WebApp_17._12._2023.Models
{
	public class InDbSQLiteCatalog : IProductRepository
	{
		private readonly AppDbContext _context;

		public InDbSQLiteCatalog(AppDbContext context)
		{
			_context = context;
		}
		public void AddProduct(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
		}

		public IReadOnlyCollection<Product> GetProducts()
		{

			return _context.Products.ToList();
		}

	}
		
}
