using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OnlineShop.Models.Dtos;
using OnlineShop.Web.Services.Contracts;

namespace OnlineShop.Web.Pages;

public class ShoppingCartBase : ComponentBase
{
    [Inject] public IJSRuntime Js { get; set; }

    [Inject] public IShoppingCartService ShoppingCartService { get; set; }

    public List<CartItemDto> ShoppingCartItems { get; set; }

    public string ErrorMessage { get; set; }

    protected string TotalPrice { get; set; }

    protected int TotalAmount { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            ShoppingCartItems = await ShoppingCartService.GetItems(TempClass.UserId);
            CalculateCartSummaryTotals();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    protected async Task DeleteCartItem_Click(int id)
    {
        var cartItemDto = await ShoppingCartService.DeleteItem(id);

        RemoveCartItem(id);
        CalculateCartSummaryTotals();
    }

    protected async Task UpdateAmountCartItem_Click(int id, int amount)
    {
        if (amount > 0)
        {
            var updateItemDto = new CartItemAmountUpdateDto
            {
                CartItemId = id,
                Amount = amount
            };

            var returnedUpdateItemDto = await ShoppingCartService.UpdateAmount(updateItemDto);

            UpdateItemTotalPrice(returnedUpdateItemDto);
            CalculateCartSummaryTotals();
            await MakeUpdateAmountButtonVisible(id, false);
        }
        else
        {
            var item = ShoppingCartItems.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                item.Amount = 1;
                item.TotalPrice = item.Price;
            }
        }
    }

    protected async Task UpdateAmount_Input(int id)
    {
        await MakeUpdateAmountButtonVisible(id, true);
    }

    private async Task MakeUpdateAmountButtonVisible(int id, bool visible)
    {
        await Js.InvokeVoidAsync("MakeUpdateAmountButtonVisible", id, visible);
    }

    private void UpdateItemTotalPrice(CartItemDto cartItemDto)
    {
        var item = GetCartItem(cartItemDto.Id);

        if (item != null) item.TotalPrice = cartItemDto.Price * cartItemDto.Amount;
    }

    private void CalculateCartSummaryTotals()
    {
        SetTotalPrice();
        SetTotalAmount();
    }

    private void SetTotalPrice()
    {
        TotalPrice = ShoppingCartItems.Sum(x => x.TotalPrice).ToString("C");
    }

    private void SetTotalAmount()
    {
        TotalAmount = ShoppingCartItems.Sum(x => x.Amount);
    }

    private CartItemDto GetCartItem(int id)
    {
        return ShoppingCartItems.FirstOrDefault(x => x.Id == id);
    }

    private void RemoveCartItem(int id)
    {
        var cartItemDto = GetCartItem(id);

        ShoppingCartItems.Remove(cartItemDto);
    }
}