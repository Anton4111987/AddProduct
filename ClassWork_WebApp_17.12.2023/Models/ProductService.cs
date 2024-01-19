using ClassWork_WebApp_17._12._2023.Data;
using ClassWork_WebApp_17._12._2023.Services;
using System.Collections.Generic;

namespace ClassWork_WebApp_17._12._2023.Models
{

    public class ProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly INowTime nowTime;
		private readonly DayOfWeek discountDay;
        public ProductService(IProductRepository productRepository)
        {
			_productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
			nowTime = new NowTimeInUTC();
			discountDay = DayOfWeek.Tuesday; // присвоение дня скидки
		}

		public IReadOnlyCollection<Product> GetProducts() 
		{
			// По воскресеньям к товарам должна применяться скидка 10%
			if (nowTime.DayOfWeek == discountDay)
			{
				
				var prod=  _productRepository.GetProducts().Result;
				var newProducts = new List<Product>(prod);
				foreach (var product in prod) 
				{
					var newProduct = new Product()
					{
						Id = product.Id,
						Name = product.Name,
						Price = product.Price - product.Price * 0.1m
					};
					
					newProducts.Add(newProduct);
				}
				return newProducts;
			
			}
			else
			{
				return _productRepository.GetProducts().Result;
			}
			
		
		}

       


	}
}
