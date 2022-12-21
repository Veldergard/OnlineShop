using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Extensions;
using OnlineShop.Api.Repositories.Contracts;
using OnlineShop.Models.Dtos;

namespace OnlineShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingCartController : ControllerBase
{
    private readonly IDishRepository dishRepository;
    private readonly IShoppingCartRepository shoppingCartRepository;

    public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IDishRepository dishRepository)
    {
        this.shoppingCartRepository = shoppingCartRepository;
        this.dishRepository = dishRepository;
    }

    [HttpGet]
    [Route("{userId}/GetItems")]
    public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
    {
        try
        {
            var cartItems = await shoppingCartRepository.GetItems(userId);

            if (cartItems == null) return NoContent();

            var dishes = await dishRepository.GetItems();

            if (dishes == null) throw new Exception("No products exist in the system");

            var cartItemsDto = cartItems.ConvertToDto(dishes);

            return Ok(cartItemsDto);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CartItemDto>> GetItem(int id)
    {
        try
        {
            var cartItem = await shoppingCartRepository.GetItem(id);

            if (cartItem == null) return NotFound();

            var dish = await dishRepository.GetItem(cartItem.DishId);

            if (dish == null) return NotFound();

            var cartItemDto = cartItem.ConvertToDto(dish);

            return Ok(cartItemDto);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CartItemDto>> PostItem([FromBody] CartItemToAddDto cartItemToAddDto)
    {
        try
        {
            var newCartItem = await shoppingCartRepository.AddItem(cartItemToAddDto);

            if (newCartItem == null) return NoContent();

            var dish = await dishRepository.GetItem(newCartItem.DishId);

            if (dish == null)
                throw new Exception(
                    $"Something went wrong when attempting to retrieve dish (dishId:({cartItemToAddDto.DishId}))");

            var newCartItemDto = newCartItem.ConvertToDto(dish);

            return CreatedAtAction(nameof(GetItem), new { id = newCartItemDto.Id }, newCartItemDto);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CartItemDto>> DeleteItem(int id)
    {
        try
        {
            var cartItem = await shoppingCartRepository.DeleteItem(id);

            if (cartItem == null) return NotFound();

            var dish = await dishRepository.GetItem(cartItem.DishId);

            if (dish == null) return NotFound();

            var cartItemDto = cartItem.ConvertToDto(dish);

            return Ok(cartItemDto);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}