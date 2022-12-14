using Microsoft.AspNetCore.Components;
using OnlineShop.Models.Dtos;
using OnlineShop.Web.Services.Contracts;

namespace OnlineShop.Web.Pages;

public class DishDetailsBase : ComponentBase
{
    [Parameter] public int Id { get; set; }

    [Inject] public IDishService DishService { get; set; }

    [Inject] public IShoppingCartService ShoppingCartService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    public DishDto Dish { get; set; }

    public string ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Dish = await DishService.GetItem(Id);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
    {
        var cartItemDto = await ShoppingCartService.AddItem(cartItemToAddDto);
        NavigationManager.NavigateTo("/ShoppingCart");
    }
}