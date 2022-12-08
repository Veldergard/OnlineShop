using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Data;
using OnlineShop.Api.Entities;
using OnlineShop.Api.Repositories.Contracts;

namespace OnlineShop.Api.Repositories
{
	public class DishRepository : IDishRepository
	{
		private readonly OnlineShopDbContext onlineShopDbContext;

		public DishRepository(OnlineShopDbContext onlineShopDbContext)
		{
			this.onlineShopDbContext = onlineShopDbContext;
		}

		public async Task<IEnumerable<DishCategory>> GetCategories()
		{
			return await this.onlineShopDbContext.DishCategories.ToListAsync();
		}

		public Task<DishCategory> GetCategory(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Dish> GetItem(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Dish>> GetItems()
		{
			return await this.onlineShopDbContext.Dishes.ToListAsync();
		}
	}
}
