using OnlineShop.Models.Dtos;

namespace OnlineShop.Web.Services.Contracts;

public interface IShoppingCartService
{
    Task<List<CartItemDto>> GetItems(int userId);
    Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto);
    Task<CartItemDto> DeleteItem(int id);
    Task<CartItemDto> UpdateAmount(CartItemAmountUpdateDto cartItemAmountUpdateDto);

    event Action<int> OnShoppingCartChanged;
    void RaiseEventOnShoppingCartChanged(int totalAmount);
}