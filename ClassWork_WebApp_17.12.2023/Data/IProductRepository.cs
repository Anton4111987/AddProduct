namespace ClassWork_WebApp_17._12._2023.Models
{
	public interface IProductRepository
	{

		public Task AddProduct(Product product);
		public Task<IReadOnlyCollection<Product>> GetProducts();
		public Task<Product?> GetProductById(int id);
	}
}