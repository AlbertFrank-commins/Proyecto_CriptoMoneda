// TODO: ApiRest/ApiService.cs
using CapaDatos;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace ApiRest
{
    // TODO: Servicio que se encarga de comunicarse con la API de CoinGecko
    public class ApiService : IDisposable
    {
        // TODO: Cliente HTTP para hacer las solicitudes
        private readonly HttpClient _httpClient;

        // TODO: Opciones de serialización JSON, ignorando mayúsculas/minúsculas en nombres de propiedades
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // TODO: Constructor
        // TODO: Permite inyectar un HttpClient externo o crea uno nuevo por defecto
        public ApiService(HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();

            // TODO: Configura encabezados y tiempo de espera del cliente
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (MonedasApp/1.0)");
            _httpClient.Timeout = TimeSpan.FromSeconds(20);
        }

        // TODO: Obtiene la lista de monedas (id, símbolo, nombre) desde CoinGecko
        public async Task<List<CoinListItem>> GetCoinListAsync(CancellationToken ct = default)
        {
            var url = "https://api.coingecko.com/api/v3/coins/list?include_platform=false";

            // TODO: Llamada HTTP GET
            using var resp = await _httpClient.GetAsync(url, ct);
            resp.EnsureSuccessStatusCode(); // TODO: Lanza excepción si no es exitoso

            var body = await resp.Content.ReadAsStringAsync(ct);

            // TODO: Deserializa JSON a lista de CoinListItem
            return JsonSerializer.Deserialize<List<CoinListItem>>(body, _jsonOptions) ?? new();
        }

        // TODO: Obtiene los detalles de una moneda específica por ID
        // TODO: Incluye precio, imagen, símbolo, nombre, etc.
        public async Task<CoinMarket?> GetCoinMarketByIdAsync(string id, string vsCurrency = "usd", CancellationToken ct = default)
        {
            // TODO: Construye la URL con parámetros de consulta
            var url = $"https://api.coingecko.com/api/v3/coins/markets?vs_currency={vsCurrency}&ids={Uri.EscapeDataString(id)}&per_page=1&page=1&sparkline=false&precision=full";

            // TODO: Llamada HTTP GET
            using var resp = await _httpClient.GetAsync(url, ct);
            resp.EnsureSuccessStatusCode(); // TODO: Lanza excepción si falla

            var body = await resp.Content.ReadAsStringAsync(ct);

            // TODO: Deserializa JSON a lista de CoinMarket
            var list = JsonSerializer.Deserialize<List<CoinMarket>>(body, _jsonOptions);

            // TODO: Devuelve el primer elemento o null si la lista está vacía
            return (list != null && list.Count > 0) ? list[0] : null;
        }

        // TODO: Implementación de IDisposable para liberar recursos del HttpClient
        public void Dispose() => _httpClient.Dispose();
    }
}
