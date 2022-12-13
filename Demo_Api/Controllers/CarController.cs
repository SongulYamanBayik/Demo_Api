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
    public class CarController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<CarListViewModel> carLists = new List<CarListViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://car-data.p.rapidapi.com/cars?limit=50&page=0"),
                Headers =
    {
        { "X-RapidAPI-Key", "15c1605dc1msh798af7ad5d4ea7ep156051jsnc58f604ecd41" },
        { "X-RapidAPI-Host", "car-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                carLists = JsonConvert.DeserializeObject<List<CarListViewModel>>(body);
                return View(carLists);

            }
        }
    }
}
