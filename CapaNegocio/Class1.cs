// CapaNegocio/MonedaCN.cs
using ApiRest;
using CapaDatos;

namespace CapaNegocio
{
    public class MonedaCN : IDisposable
    {
        private readonly ApiService _api;
        private List<CoinListItem> _cacheLista = new();
        private DateTime _cacheFecha = DateTime.MinValue;
        private readonly TimeSpan _cacheTTL = TimeSpan.FromMinutes(30);


        public MonedaCN(ApiService? api = null)
        {
            _api = api ?? new ApiService();
        }

        private async Task EnsureListaAsync(CancellationToken ct = default)
        {
            if (_cacheLista.Count == 0 || DateTime.UtcNow - _cacheFecha > _cacheTTL)
            {
                _cacheLista = await _api.GetCoinListAsync(ct);
                _cacheFecha = DateTime.UtcNow;
            }
        }

        // Búsqueda directa por ID
        public Task<CoinMarket?> BuscarPorIdAsync(string id, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(id)) return Task.FromResult<CoinMarket?>(null);
            return _api.GetCoinMarketByIdAsync(id.Trim(), "usd", ct);
        }

        // Búsqueda por Nombre (exacto; si no, "contains")
        public async Task<CoinMarket?> BuscarPorNombreAsync(string nombre, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return null;
            await EnsureListaAsync(ct);

            var q = nombre.Trim();
            var item = _cacheLista.FirstOrDefault(x => x.name.Equals(q, StringComparison.OrdinalIgnoreCase))
                    ?? _cacheLista.FirstOrDefault(x => x.name.Contains(q, StringComparison.OrdinalIgnoreCase));

            return item != null ? await _api.GetCoinMarketByIdAsync(item.id, "usd", ct) : null;
        }

        // Búsqueda por Símbolo (pueden existir duplicados; se toma el primero)
        public async Task<CoinMarket?> BuscarPorSimboloAsync(string simbolo, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(simbolo)) return null;
            await EnsureListaAsync(ct);

            var q = simbolo.Trim();
            var item = _cacheLista.FirstOrDefault(x => x.symbol.Equals(q, StringComparison.OrdinalIgnoreCase))
                    ?? _cacheLista.FirstOrDefault(x => x.symbol.Contains(q, StringComparison.OrdinalIgnoreCase));

            return item != null ? await _api.GetCoinMarketByIdAsync(item.id, "usd", ct) : null;
        }

        // Devuelve la lista cacheada para autocompletar, combos, etc.
        public async Task<List<CoinListItem>> ObtenerListaAsync(CancellationToken ct = default)
        {
            await EnsureListaAsync(ct);
            return _cacheLista;
        }

        public void LimpiarCache()
        {
            _cacheLista.Clear();
            _cacheFecha = DateTime.MinValue;
        }

        public void Dispose() => _api.Dispose();
    
    
    
        private readonly CoinGeckoChartService _chartService;

        public MonedaCN()
        {
            _chartService = new CoinGeckoChartService();
        }

        public async Task<MarketChartDataModel> ObtenerDatosGrafico(string id, string intervalo = "Días")
        {
            return await _chartService.GetMarketChartDataAsync(id, intervalo);
        }
    }
}

