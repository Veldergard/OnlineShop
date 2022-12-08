using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.Dtos
{
	public class DishDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageURL { get; set; }
		public decimal Price { get; set; }
		public int Amount { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}
