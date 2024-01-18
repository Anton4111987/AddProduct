using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ClassWork_WebApp_17._12._2023.Models
{
	public class Product // сущность 
	{

		public int Id { get; set; }

		[Required(ErrorMessage="Название продукта не может быть пустым")]
		public string? Name { get; set; }

		[Required(ErrorMessage ="Заполните поле цена продукта")]
		[Range(0, 1_000_000, ErrorMessage ="Wtyf должна быть от  0 до 1000000")]
		public decimal Price { get; set; }

		public override string ToString()
		{
			return Id.ToString() + " " + Name?.ToString() + " " + Price.ToString();
		}
	}
}


