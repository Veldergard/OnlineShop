using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Data;
using OnlineShop.Api.Entities;
using OnlineShop.Api.Repositories.Contracts;

namespace OnlineShop.Api.Repositories;

public class DishRepository : IDishRepository
{
    private readonly OnlineShopDbContext onlineShopDbContext;

    public DishRepository(OnlineShopDbContext onlineShopDbContext)
    {
        this.onlineShopDbContext = onlineShopDbContext;
    }

    public async Task<IEnumerable<DishCategory>> GetCategories()
    {
        return await onlineShopDbContext.DishCategories.ToListAsync();
    }

    public async Task<DishCategory> GetCategory(int id)
    {
        return await onlineShopDbContext.DishCategories.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Dish> GetItem(int id)
    {
        return await onlineShopDbContext.Dishes.FindAsync(id);
    }

    public async Task<IEnumerable<Dish>> GetItems()
    {
        return await onlineShopDbContext.Dishes.ToListAsync();
    }
}