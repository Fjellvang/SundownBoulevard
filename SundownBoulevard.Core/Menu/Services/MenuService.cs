using SundownBoulevard.Core.Common;
using SundownBoulevard.Core.Menu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Menu.Services
{
	public class MenuService
	{
		public const string MenuEndpoint = "https://www.themealdb.com/api/json/v1/1/random.php";
		public const string BeerEndpoint = "https://api.punkapi.com/v2/beers";

		public Task<FoodMenuDto> GetFoodMenu()
		{
			var client = new RestClient();
			return client.GetResponseAsync<FoodMenuDto>(MenuEndpoint);
		}
		public Task<BeerMenuDto> GetBeerMenu()
		{
			var client = new RestClient();
			return client.GetResponseAsync<BeerMenuDto>(BeerEndpoint);
		}
	}
}
