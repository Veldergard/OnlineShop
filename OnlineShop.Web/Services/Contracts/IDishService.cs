using OnlineShop.Models.Dtos;

namespace OnlineShop.Web.Services.Contracts;

public interface IDishService
{
    Task<IEnumerable<DishDto>> GetItems();
    Task<DishDto> GetItem(int id);
}