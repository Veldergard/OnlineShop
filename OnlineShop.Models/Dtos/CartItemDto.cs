namespace OnlineShop.Models.Dtos;

public class CartItemDto
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int DishId { get; set; }
    public string DishName { get; set; }
    public string DishDescription { get; set; }
    public string DishImageURL { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public int Amount { get; set; }
}