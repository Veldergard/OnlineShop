using System.Net;
using System.Net.Http.Json;
using OnlineShop.Models.Dtos;
using OnlineShop.Web.Services.Contracts;

namespace OnlineShop.Web.Services;

public class DishService : IDishService
{
    private readonly HttpClient httpClient;

    public DishService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<DishDto> GetItem(int id)
    {
        var response = await httpClient.GetAsync($"api/Dish/{id}");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent) return default;

            return await response.Content.ReadFromJsonAsync<DishDto>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<IEnumerable<DishDto>> GetItems()
    {
        var response = await httpClient.GetAsync("api/Dish");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent) return Enumerable.Empty<DishDto>();

            return await response.Content.ReadFromJsonAsync<IEnumerable<DishDto>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }
}