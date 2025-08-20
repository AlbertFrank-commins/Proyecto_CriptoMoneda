using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public class CoinGeckoDescriptionService
{
    private readonly HttpClient _http;

    public CoinGeckoDescriptionService(HttpClient http)
    {
        _http = http;
    }

    public async Task<string> GetDescriptionAsync(string coinId, CancellationToken token)
    {
        var url = $"https://api.coingecko.com/api/v3/coins/{coinId.ToLower()}";
        var response = await _http.GetAsync(url, token);

        response.EnsureSuccessStatusCode();

        using var stream = await response.Content.ReadAsStreamAsync(token);

        var json = await JsonDocument.ParseAsync(stream, cancellationToken: token);
        var description = json.RootElement
            .GetProperty("description")
            .GetProperty("en")
            .GetString();

        return description ?? "No description available.";
    }
}
