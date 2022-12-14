using OnlineShop.Models.Dtos;
using OnlineShop.Web.Services.Contracts;
using System.Net.Http.Json;

namespace OnlineShop.Web.Services
{
	public class DishService : IDishService
	{
		private readonly HttpClient httpClient;

		public DishService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<IEnumerable<DishDto>> GetItems()
		{
			try
			{
				var dishes = await this.httpClient.GetFromJsonAsync<IEnumerable<DishDto>>("api/Dish");
				return dishes;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
