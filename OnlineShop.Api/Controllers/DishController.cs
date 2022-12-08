using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Extensions;
using OnlineShop.Api.Repositories.Contracts;
using OnlineShop.Models.Dtos;

namespace OnlineShop.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DishController : ControllerBase
	{
		private readonly IDishRepository dishRepository;

		public DishController(IDishRepository dishRepository)
		{
			this.dishRepository = dishRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<DishDto>>> GetItems()
		{
			try
			{
				var dishes = await this.dishRepository.GetItems();
				var dishCategories = await this.dishRepository.GetCategories();

				if (dishes == null || dishCategories == null)
				{
					return NotFound();
				}

				var dishDtos = dishes.ConvertToDto(dishCategories);

				return Ok(dishDtos);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error while retrieving data from database");
			}
		}
	}
}
