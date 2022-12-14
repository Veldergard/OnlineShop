using Microsoft.AspNetCore.Components;
using OnlineShop.Models.Dtos;
using OnlineShop.Web.Services.Contracts;

namespace OnlineShop.Web.Pages;

public class DishesBase : ComponentBase
{
    [Inject] public IDishService DishService { get; set; }

    public IEnumerable<DishDto> Dishes { get; set; }

    public string ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Dishes = await DishService.GetItems();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    protected IOrderedEnumerable<IGrouping<int, DishDto>> GetGroupedDishesByCategory()
    {
        return from dish in Dishes
            group dish by dish.CategoryId
            into dishByCatGroup
            orderby dishByCatGroup.Key
            select dishByCatGroup;
    }

    protected string GetCategoryName(IGrouping<int, DishDto> groupedDishDto)
    {
        return groupedDishDto.FirstOrDefault(dg => dg.CategoryId == groupedDishDto.Key).CategoryName;
    }
}