using Microsoft.AspNetCore.Components;
using OnlineShop.Models.Dtos;

namespace OnlineShop.Web.Pages;

public class DisplayDishesBase : ComponentBase
{
    [Parameter] public IEnumerable<DishDto> Dishes { get; set; }
}