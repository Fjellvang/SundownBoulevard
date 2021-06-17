using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SundownBoulevard.Core.Common;
using SundownBoulevard.Core.Menu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Menu.Controller
{
	[ApiController]
	[Route("api/[controller]")]
	public class MenuController : ControllerBase
	{
		private readonly AppSettings options;

		public MenuController(IOptions<AppSettings> options)
		{
			this.options = options.Value;
		}
		[HttpGet(nameof(GetBeerMenu))]
		public async Task<IActionResult> GetBeerMenu(int page = 1, int pageSize = 20)
		{
			var client = new RestClient();
			var menu = await client.GetResponseAsync<Beer[]>($"{options.BeerMenuEndpoint}?page={page}&per_page={pageSize}");

			return Ok(menu.Select(x => new { x.Name, x.Id })); // a proper view DTO with more details would be nice.
		}

		[HttpGet(nameof(GetFoodMenu))]
		public async Task<IActionResult> GetFoodMenu()
		{
			var client = new RestClient();
			var menu = await client.GetResponseAsync<FoodMenuDto>(options.FoodMenuEndpoint);

			return Ok(menu.meals.Select(x => new { Name = x.StrMeal, Id = x.IdMeal }));
		}
	}
}
