using ClassWork_WebApp_17._12._2023.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClassWork_WebApp_17._12._2023.Data
{
    public class InDbSQLiteCatalog : IProductRepository
    {
        private readonly AppDbContext _context;


        public InDbSQLiteCatalog(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
		public async Task AddProduct(Product product)
		{
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
		}

		public async Task<IReadOnlyCollection<Product>?> GetProducts()
		{
			var list = await _context.Products.ToListAsync();
			return list.AsReadOnly();
		}
		public async Task<Product?> GetProductById(int id)
		{
			return await _context.Products.FindAsync(id);
		}

	}

}
