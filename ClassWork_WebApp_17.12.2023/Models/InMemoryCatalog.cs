using System.Collections.Generic;

namespace ClassWork_WebApp_17._12._2023.Models
{

	public class InMemoryCatalog : IProductRepository
	{
		
		private readonly List<Product> _products = new()
		{
			new Product {Id=1, Name="Чистый код", Price=1000  },
			new Product {Id=2, Name="Грязный код", Price=2000  }
		};
        public IReadOnlyCollection<Product> GetProducts()
        {
			return _products ;
		}
        
		public void AddProduct(Product product)
		{
			_products.Add(product);

		}
	


	}

	
}
