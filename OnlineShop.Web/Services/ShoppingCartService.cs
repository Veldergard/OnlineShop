using System.Net;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
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

    public async Task<CartItemDto> DeleteItem(int id)
    {
        var response = await httpClient.DeleteAsync($"api/ShoppingCart/{id}");

        if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<CartItemDto>();

        return default;
    }

    public async Task<List<CartItemDto>> GetItems(int userId)
    {
        var response = await httpClient.GetAsync($"api/ShoppingCart/{userId}/GetItems");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent) return Enumerable.Empty<CartItemDto>().ToList();

            return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
    }

    public async Task<CartItemDto> UpdateAmount(CartItemAmountUpdateDto cartItemAmountUpdateDto)
    {
        var jsonRequest = JsonConvert.SerializeObject(cartItemAmountUpdateDto);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

        var response = await httpClient.PatchAsync($"api/ShoppingCart/{cartItemAmountUpdateDto.CartItemId}", content);

        if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<CartItemDto>();

        return null;
    }
}