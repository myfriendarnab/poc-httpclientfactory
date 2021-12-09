using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace httpclientfactoryTest
{
    public class MyService : IMyService
    {
        private readonly HttpClient _apiClient;
        // private readonly ILogger<MyService> _logger;
        private readonly string _basketByPassUrl;

public MyService(HttpClient httpClient)
{
    _apiClient = httpClient;
}

        public async Task<bool> SearchShipperBooking()
        {
            var content = new StringContent(@"{}",Encoding.UTF8);
            var result = await _apiClient.PostAsync("https://apiazewtmlns001sgproxy.azurewebsites.net/", content);
            return result.IsSuccessStatusCode;
        }
    }

    public interface IMyService
    {
        Task<bool> SearchShipperBooking();

    }
}