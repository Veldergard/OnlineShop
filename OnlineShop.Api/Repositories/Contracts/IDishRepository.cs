using OnlineShop.Api.Entities;

namespace OnlineShop.Api.Repositories.Contracts
{
	public interface IDishRepository
	{
		Task<IEnumerable<Dish>> GetItems();
		Task<IEnumerable<DishCategory>> GetCategories();
		Task<Dish> GetItem(int id);
		Task<DishCategory> GetCategory(int id);
	}
}
