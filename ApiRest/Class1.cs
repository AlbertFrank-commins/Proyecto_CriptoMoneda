// ApiRest/ApiService.cs
using CapaDatos;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace ApiRest
{
    public class ApiService : IDisposable
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public ApiService(HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (MonedasApp/1.0)");
            _httpClient.Timeout = TimeSpan.FromSeconds(20);
        }

        // Lista de monedas (id, symbol, name)
        public async Task<List<CoinListItem>> GetCoinListAsync(CancellationToken ct = default)
        {
            var url = "https://api.coingecko.com/api/v3/coins/list?include_platform=false";
            using var resp = await _httpClient.GetAsync(url, ct);
            resp.EnsureSuccessStatusCode();
            var body = await resp.Content.ReadAsStringAsync(ct);
            return JsonSerializer.Deserialize<List<CoinListItem>>(body, _jsonOptions) ?? new();
        }

        // Detalle por ID (precio, imagen, etc.)
        public async Task<CoinMarket?> GetCoinMarketByIdAsync(string id, string vsCurrency = "usd", CancellationToken ct = default)
        {
            var url = $"https://api.coingecko.com/api/v3/coins/markets?vs_currency={vsCurrency}&ids={Uri.EscapeDataString(id)}&per_page=1&page=1&sparkline=false&precision=full";
            using var resp = await _httpClient.GetAsync(url, ct);
            resp.EnsureSuccessStatusCode();
            var body = await resp.Content.ReadAsStringAsync(ct);
            var list = JsonSerializer.Deserialize<List<CoinMarket>>(body, _jsonOptions);
            return (list != null && list.Count > 0) ? list[0] : null;
        }

        public void Dispose() => _httpClient.Dispose();
    }
    // LLamado de la Api para el manejo de los Graficos 
    public class CoinGeckoChartService
    {
        private readonly HttpClient _httpClient;

        public CoinGeckoChartService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
        }

        public async Task<MarketChartDataModel> GetMarketChartDataAsync(string id, string intervalo = "Días")
        {
            string days = intervalo switch
            {
                "Minutos" => "1",
                "Horas" => "30",
                _ => "90"
            };

            string urlInfo = $"https://api.coingecko.com/api/v3/coins/{id}?localization=false";
            string urlChart = $"https://api.coingecko.com/api/v3/coins/{id}/market_chart?vs_currency=usd&days={days}";

            // Info general
            string responseInfo = await _httpClient.GetStringAsync(urlInfo);
            JObject infoJson = JObject.Parse(responseInfo);
            string name = infoJson["name"].ToString();
            string imageUrl = infoJson["image"]["small"].ToString();

            // Precios
            string responseChart = await _httpClient.GetStringAsync(urlChart);
            JObject chartJson = JObject.Parse(responseChart);
            var pricesArray = (JArray)chartJson["prices"];

            var dataPoints = new List<DataPoint>();
            foreach (var point in pricesArray)
            {
                long unix = point[0].Value<long>();
                double price = point[1].Value<double>();
                DateTime date = DateTimeOffset.FromUnixTimeMilliseconds(unix).DateTime;

                dataPoints.Add(new DataPoint { Date = date, Price = price });
            }

            return new MarketChartDataModel
            {
                Id = id,
                Name = name,
                ImageUrl = imageUrl,
                DataPoints = dataPoints
            };
        }
    }
}
