using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

public class CoinGeckoDescriptionService
{
    private readonly HttpClient _http;

    public CoinGeckoDescriptionService(HttpClient http)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
        if (!_http.DefaultRequestHeaders.Contains("User-Agent"))
            _http.DefaultRequestHeaders.Add("User-Agent", "RecetasWinForms/1.0");
    }

    public async Task<string> GetDescriptionAsync(string coinId, CancellationToken token, IProgress<int> progress = null)
    {
        progress?.Report(5);

        // Simular carga
        for (int i = 1; i <= 3; i++)
        {
            token.ThrowIfCancellationRequested();
            await Task.Delay(400, token);
            progress?.Report(i * 20); // 20%, 40%, 60%
        }

        var url = $"https://api.coingecko.com/api/v3/coins/{coinId.ToLower()}";
        var response = await _http.GetAsync(url, token);
        progress?.Report(80);

        if (response.StatusCode == (HttpStatusCode)429)
            throw new InvalidOperationException("Límite de peticiones alcanzado (429)");

        response.EnsureSuccessStatusCode();

        await using var stream = await response.Content.ReadAsStreamAsync(token);
        string raw = null;

        try
        {
            using var json = await JsonDocument.ParseAsync(stream, cancellationToken: token);

            if (json.RootElement.TryGetProperty("description", out var descObj) &&
                descObj.ValueKind == JsonValueKind.Object &&
                descObj.TryGetProperty("en", out var enProp) &&
                enProp.ValueKind == JsonValueKind.String)
            {
                raw = enProp.GetString();
            }
        }
        catch
        {
            raw = null;
        }

        var clean = CleanHtml(raw);
        progress?.Report(100);

        return string.IsNullOrWhiteSpace(clean) ? "No description available." : clean;
    }

    private static string CleanHtml(string html)
    {
        if (string.IsNullOrEmpty(html)) return "";
        var decoded = WebUtility.HtmlDecode(html);
        var noTags = Regex.Replace(decoded, "<.*?>", string.Empty).Trim();
        noTags = Regex.Replace(noTags, @"\s{2,}", " ");
        return noTags;
    }
}
