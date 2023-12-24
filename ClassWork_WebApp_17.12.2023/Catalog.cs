namespace ClassWork_WebApp_17._12._2023
{
    
    public class Catalog
    {
       
        private readonly List<Product> _products = new()
        {
            new Product {Id=1, Name="Чистый код", Price=12345  },
            new Product {Id=2, Name="Грязный код", Price=9573562  }
        };
        public Product[] GetProducts()
        {
            return _products.ToArray();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);

        }

    }

    public class Product
    {
     
		public int Id { get; set; }
        public string? Name { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return Id.ToString()+" "+ Name?.ToString()+" "+Price.ToString();
        }
    }
}
