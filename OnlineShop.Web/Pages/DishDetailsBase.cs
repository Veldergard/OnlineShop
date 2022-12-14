using Microsoft.AspNetCore.Components;
using OnlineShop.Models.Dtos;
using OnlineShop.Web.Services.Contracts;

namespace OnlineShop.Web.Pages;

public class DishDetailsBase : ComponentBase
{
    [Parameter] public int Id { get; set; }

    [Inject] public IDishService DishService { get; set; }

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
}