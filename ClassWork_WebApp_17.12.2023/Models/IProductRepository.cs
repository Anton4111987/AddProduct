namespace ClassWork_WebApp_17._12._2023.Models
{
	public interface IProductRepository
	{

		void AddProduct(Product product);
		IReadOnlyCollection<Product> GetProducts();
	}
}