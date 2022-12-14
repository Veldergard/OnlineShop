using System.Net;
using System.Net.Http.Json;
using OnlineShop.Models.Dtos;
using OnlineShop.Web.Services.Contracts;

namespace OnlineShop.Web.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly HttpClient httpClient;

    public ShoppingCartService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto)
    {
        var response = await httpClient.PostAsJsonAsync("api/ShoppingCart", cartItemToAddDto);

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent) return default;

            return await response.Content.ReadFromJsonAsync<CartItemDto>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception($"Http status:{response.StatusCode} Message - {message}");
    }

    public async Task<IEnumerable<CartItemDto>> GetItems(int userId)
    {
        var response = await httpClient.GetAsync($"api/ShoppingCart/{userId}/GetItems");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent) return Enumerable.Empty<CartItemDto>();

            return await response.Content.ReadFromJsonAsync<IEnumerable<CartItemDto>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
    }
}