namespace OnlineShop.Api.Entities;

public class CartItem
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int DishId { get; set; }
    public int Amount { get; set; }
}