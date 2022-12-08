namespace OnlineShop.Api.Entities
{
	public class Dish
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageURL { get; set; }
		public decimal Price { get; set; }
		public int Amount { get; set; }
		public int CategoryId { get; set; }
	}
}
