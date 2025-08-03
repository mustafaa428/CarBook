using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {


            var LocationId = TempData["LocationId"];
            ViewBag.LocationId = LocationId;

            id = int.Parse(LocationId.ToString());

            var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(filterRentACarDto);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.GetAsync($"https://localhost:7120/api/RentACars?LocationId={id}&Available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }
            return View();

        }
    }
}
