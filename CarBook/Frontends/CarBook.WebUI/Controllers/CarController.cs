using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title1 = "Ana sayfa";
            ViewBag.Title2 = "Arabalar";
            ViewBag.Title3 = "Arabanızı seçin";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7120/api/CarPricings/GetCarWithPricing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetCarPricingWithCarDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.Title1 = "Ana sayfa";
            ViewBag.Title2 = "Araba Detayı";
            ViewBag.Title3 = "Araba Detay Bilgileri";

            ViewBag.CarId = id;
            return View();
        }
    }
}

