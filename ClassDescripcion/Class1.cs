using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

// TODO: Servicio que obtiene la descripción de una moneda desde CoinGecko
public class CoinGeckoDescriptionService
{
    // TODO: Cliente HTTP para realizar solicitudes a la API
    private readonly HttpClient _http;

    // TODO: Constructor que recibe un HttpClient inyectado
    public CoinGeckoDescriptionService(HttpClient http)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));

        // TODO: Agrega User-Agent si no existe
        if (!_http.DefaultRequestHeaders.Contains("User-Agent"))
            _http.DefaultRequestHeaders.Add("User-Agent", "RecetasWinForms/1.0");
    }

    // TODO: Obtiene la descripción en inglés de una moneda
    // TODO: Soporta cancelación y progreso
    public async Task<string> GetDescriptionAsync(string coinId, CancellationToken token, IProgress<int> progress = null)
    {
        progress?.Report(5); // TODO: Reporta progreso inicial 5%

        // TODO: Simula carga progresiva (opcional, para barra de progreso)
        for (int i = 1; i <= 3; i++)
        {
            token.ThrowIfCancellationRequested(); // TODO: Permite cancelar la operación
            await Task.Delay(400, token);        // TODO: Simula tiempo de carga
            progress?.Report(i * 20);           // TODO: Reporta 20%, 40%, 60%
        }

        // TODO: Construye URL para obtener información de la moneda
        var url = $"https://api.coingecko.com/api/v3/coins/{coinId.ToLower()}";

        // TODO: Llamada HTTP GET
        var response = await _http.GetAsync(url, token);
        progress?.Report(80); // TODO: Reporta progreso 80%

        // TODO: Maneja límite de peticiones 429
        if (response.StatusCode == (HttpStatusCode)429)
            throw new InvalidOperationException("Límite de peticiones alcanzado (429)");

        response.EnsureSuccessStatusCode(); // TODO: Lanza excepción si no es exitoso

        // TODO: Lee el contenido como stream
        await using var stream = await response.Content.ReadAsStreamAsync(token);

        string raw = null;

        try
        {
            // TODO: Parsea JSON para obtener description.en
            using var json = await JsonDocument.ParseAsync(stream, cancellationToken: token);

            if (json.RootElement.TryGetProperty("description", out var descObj) &&
                descObj.ValueKind == JsonValueKind.Object &&
                descObj.TryGetProperty("en", out var enProp) &&
                enProp.ValueKind == JsonValueKind.String)
            {
                raw = enProp.GetString(); // TODO: Texto crudo
            }
        }
        catch
        {
            raw = null; // TODO: Ignora errores de parsing
        }

        // TODO: Limpia HTML y codificación
        var clean = CleanHtml(raw);
        progress?.Report(100); // TODO: Reporta progreso 100%

        // TODO: Retorna la descripción limpia o mensaje por defecto
        return string.IsNullOrWhiteSpace(clean) ? "No description available." : clean;
    }

    // TODO: Método privado que elimina etiquetas HTML y espacios extra
    private static string CleanHtml(string html)
    {
        if (string.IsNullOrEmpty(html)) return "";
        var decoded = WebUtility.HtmlDecode(html);                 // TODO: Decodifica entidades HTML
        var noTags = Regex.Replace(decoded, "<.*?>", string.Empty).Trim(); // TODO: Elimina tags HTML
        noTags = Regex.Replace(noTags, @"\s{2,}", " ");           // TODO: Normaliza espacios múltiples
        return noTags;
    }
}

