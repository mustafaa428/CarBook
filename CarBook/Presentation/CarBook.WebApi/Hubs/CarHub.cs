using CarBook.Application.Features.CQRS.Results.CarResults;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

namespace CarBook.WebApi.Hubs
{
    public class CarHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7120/api/Cars");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // JSON'u liste olarak deserialize et
                var cars = JsonSerializer.Deserialize<List<GetCarQueryResult>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var carcount = cars?.Count ?? 0;

                await Clients.All.SendAsync("ReceiveCarCount", carcount);
            }
            else
            {
                // API'den hata geldiyse 0 gönder
                await Clients.All.SendAsync("ReceiveCarCount", 0);
            }
        }
    }
}
