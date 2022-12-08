using OnlineShop.Api.Entities;
using OnlineShop.Models.Dtos;

namespace OnlineShop.Api.Extensions
{
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
	}
}
