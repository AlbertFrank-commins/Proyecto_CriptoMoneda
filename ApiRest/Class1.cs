using System.Text.Json;
using CapaDatos;

namespace ApiRest
{
    public class ApiService
    { 
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task <List<Root>>  GetMonedasAsync()
        {
            var response = await _httpClient.GetAsync("https://api.coingecko.com/api/v3/coins/list");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Root>>(responseBody);
        }
    }
}



