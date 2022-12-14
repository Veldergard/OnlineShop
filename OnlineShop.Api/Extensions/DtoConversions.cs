using OnlineShop.Api.Entities;
using OnlineShop.Models.Dtos;

namespace OnlineShop.Api.Extensions;

public static class DtoConversions
{
    public static IEnumerable<DishDto> ConvertToDto(this IEnumerable<Dish> dishes,
        IEnumerable<DishCategory> dishCategories)
    {
        return (from dish in dishes
            join dishCategory in dishCategories
                on dish.CategoryId equals dishCategory.Id
            select new DishDto
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                ImageURL = dish.ImageURL,
                Price = dish.Price,
                Amount = dish.Amount,
                CategoryId = dish.CategoryId,
                CategoryName = dishCategory.Name
            }).ToList();
    }

    public static DishDto ConvertToDto(this Dish dish,
        DishCategory dishCategory)
    {
        return new DishDto
        {
            Id = dish.Id,
            Name = dish.Name,
            Description = dish.Description,
            ImageURL = dish.ImageURL,
            Price = dish.Price,
            Amount = dish.Amount,
            CategoryId = dish.CategoryId,
            CategoryName = dishCategory.Name
        };
    }

    public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems,
        IEnumerable<Dish> dishes)
    {
        return (from cartItem in cartItems
            join dish in dishes
                on cartItem.DishId equals dish.Id
            select new CartItemDto
            {
                Id = cartItem.Id,
                CartId = cartItem.CartId,
                DishId = cartItem.DishId,
                DishName = dish.Name,
                DishDescription = dish.Description,
                DishImageURL = dish.ImageURL,
                Price = dish.Price,
                Amount = cartItem.Amount,
                TotalPrice = dish.Price * cartItem.Amount
            }).ToList();
    }

    public static CartItemDto ConvertToDto(this CartItem cartItem,
        Dish dish)
    {
        return new CartItemDto
        {
            Id = cartItem.Id,
            CartId = cartItem.CartId,
            DishId = cartItem.DishId,
            DishName = dish.Name,
            DishDescription = dish.Description,
            DishImageURL = dish.ImageURL,
            Price = dish.Price,
            Amount = cartItem.Amount,
            TotalPrice = dish.Price * cartItem.Amount
        };
    }
}