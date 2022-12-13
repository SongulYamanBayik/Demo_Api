using Demo_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo_Api.Controllers
{
    public class MovieController : Controller
    {
		List<MovieListViewModel> movies = new List<MovieListViewModel>();
        public async Task<IActionResult> Index()
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
	{
		{ "X-RapidAPI-Key", "15c1605dc1msh798af7ad5d4ea7ep156051jsnc58f604ecd41" },
		{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				movies = JsonConvert.DeserializeObject<List<MovieListViewModel>>(body);
				return View(movies);
			}
		}
    }
}
