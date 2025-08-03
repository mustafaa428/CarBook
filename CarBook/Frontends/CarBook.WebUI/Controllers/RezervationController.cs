using CarBook.Dto.LocationDtos;
using CarBook.Dto.RezervationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RezervationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RezervationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7120/api/Locations");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> value2 = (from item in values
                                           select new SelectListItem
                                           {
                                               Text = item.Name,
                                               Value = item.LocationId.ToString()
                                           }
                                           ).ToList();

            ViewBag.v = value2;
            ViewBag.carId = id;
            ViewBag.Title1 = "Ana sayfa";
            ViewBag.Title2 = "Araç Kiralama";
            ViewBag.Title3 = "Araç Kiralama Formu";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateRezervationDto create)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(create);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7120/api/Rezervations", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            return View();
        }
    }
}
