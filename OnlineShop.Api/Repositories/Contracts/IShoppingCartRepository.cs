using OnlineShop.Api.Entities;
using OnlineShop.Models.Dtos;

namespace OnlineShop.Api.Repositories.Contracts;

public interface IShoppingCartRepository
{
    Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);
    Task<CartItem> UpdateAmount(int id, CartItemAmountUpdateDto cartItemAmountUpdateDto);
    Task<CartItem> DeleteItem(int id);
    Task<CartItem> GetItem(int id);
    Task<IEnumerable<CartItem>> GetItems(int userId);
}