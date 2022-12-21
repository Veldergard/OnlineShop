using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Data;
using OnlineShop.Api.Entities;
using OnlineShop.Api.Repositories.Contracts;
using OnlineShop.Models.Dtos;

namespace OnlineShop.Api.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly OnlineShopDbContext onlineShopDbContext;

    public ShoppingCartRepository(OnlineShopDbContext onlineShopDbContext)
    {
        this.onlineShopDbContext = onlineShopDbContext;
    }

    public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
    {
        if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.DishId) == false)
        {
            var item = await (from dish in onlineShopDbContext.Dishes
                where dish.Id == cartItemToAddDto.DishId
                select new CartItem
                {
                    CartId = cartItemToAddDto.CartId,
                    DishId = dish.Id,
                    Amount = cartItemToAddDto.Amount
                }).SingleOrDefaultAsync();

            if (item != null)
            {
                var result = await onlineShopDbContext.CartItems.AddAsync(item);
                await onlineShopDbContext.SaveChangesAsync();
                return result.Entity;
            }
        }

        return null;
    }

    public async Task<CartItem> DeleteItem(int id)
    {
        var item = await onlineShopDbContext.CartItems.FindAsync(id);

        if (item != null)
        {
            onlineShopDbContext.CartItems.Remove(item);
            await onlineShopDbContext.SaveChangesAsync();
        }

        return item;
    }

    public async Task<CartItem> GetItem(int id)
    {
        return await (
            from cart in onlineShopDbContext.Carts
            join cartItem in onlineShopDbContext.CartItems
                on cart.Id equals cartItem.CartId
            where cartItem.Id == id
            select new CartItem
            {
                Id = cartItem.Id,
                DishId = cartItem.DishId,
                Amount = cartItem.Amount,
                CartId = cartItem.CartId
            }).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<CartItem>> GetItems(int userId)
    {
        return await (from cart in onlineShopDbContext.Carts
            join cartItem in onlineShopDbContext.CartItems
                on cart.Id equals cartItem.CartId
            where cart.UserId == userId
            select new CartItem
            {
                Id = cartItem.Id,
                DishId = cartItem.DishId,
                Amount = cartItem.Amount,
                CartId = cartItem.CartId
            }).ToListAsync();
    }

    public Task<CartItem> UpdateAmount(int id, CartItemAmountUpdateDto cartItemAmountUpdateDto)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> CartItemExists(int cartId, int dishId)
    {
        return await onlineShopDbContext.CartItems.AnyAsync(c =>
            c.CartId == cartId &&
            c.DishId == dishId
        );
    }
}