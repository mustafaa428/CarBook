using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/AdminLocation")]
    public class AdminLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var accessTokenClaim = User.Claims.FirstOrDefault(x => x.Type == "accessToken");
            if (accessTokenClaim == null)
            {
                // Token yoksa yetkisiz, AccessDenied sayfasına yönlendir
                return RedirectToAction("AccessDenied", "Page");
            }

            var token = accessTokenClaim.Value;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.GetAsync("https://localhost:7120/api/Locations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return View(values);
            }


            return View();
        }

        [HttpGet]
        [Route("CreateLocation")]
        public IActionResult CreateLocation()
        {

            return View();
        }

        [HttpPost]
        [Route("CreateLocation")]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var accessTokenClaim = User.Claims.FirstOrDefault(x => x.Type == "accessToken");
            if (accessTokenClaim == null)
            {
                // Token yoksa yetkisiz, AccessDenied sayfasına yönlendir
                return RedirectToAction("AccessDenied", "Page");
            }

            var token = accessTokenClaim.Value;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var jsonData = JsonConvert.SerializeObject(createLocationDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7120/api/Locations", content);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                responseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                return RedirectToAction("AccessDenied", "Page");
            }
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteLocation/{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var accessTokenClaim = User.Claims.FirstOrDefault(x => x.Type == "accessToken");
            if (accessTokenClaim == null)
            {
                // Token yoksa yetkisiz, AccessDenied sayfasına yönlendir
                return RedirectToAction("AccessDenied", "Page");
            }

            var token = accessTokenClaim.Value;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.DeleteAsync("https://localhost:7120/api/Locations?id=" + id);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                responseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                return RedirectToAction("AccessDenied", "Page");
            }

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var accessTokenClaim = User.Claims.FirstOrDefault(x => x.Type == "accessToken");
            if (accessTokenClaim == null)
            {
                // Token yoksa yetkisiz, AccessDenied sayfasına yönlendir
                return RedirectToAction("AccessDenied", "Page");
            }

            var token = accessTokenClaim.Value;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.GetAsync("https://localhost:7120/api/Locations/" + id);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                responseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                return RedirectToAction("AccessDenied", "Page");
            }
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var accessTokenClaim = User.Claims.FirstOrDefault(x => x.Type == "accessToken");
            if (accessTokenClaim == null)
            {
                // Token yoksa yetkisiz, AccessDenied sayfasına yönlendir
                return RedirectToAction("AccessDenied", "Page");
            }

            var token = accessTokenClaim.Value;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var jsonData = JsonConvert.SerializeObject(updateLocationDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7120/api/Locations", content);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                responseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                return RedirectToAction("AccessDenied", "Page");
            }
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }
    }
}
