using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Common
{
	public class RestClient
	{
		private readonly static HttpClient client = new();

		public async Task<T> GetResponseAsync<T>(string endpoint)
		{
			var response = await client.GetAsync(endpoint);
			if (response.StatusCode != HttpStatusCode.OK)
			{
				return default; // TODO: nicer error handling.
			}
			var data = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<T>(data);
		}

	}
}
