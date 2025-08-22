// CapaNegocio/MonedaCN.cs
using ApiRest;
using CapaDatos;

namespace CapaNegocio
{
    public class MonedaCN : IDisposable
    {
        // Instancia del servicio de API para realizar llamadas a la API externa.
        private readonly ApiService _api;
        // Lista en caché de monedas obtenidas desde la API, usada para búsquedas rápidas.
        private List<CoinListItem> _cacheLista = new();
        // Fecha y hora en que se actualizó por última vez la caché.
        private DateTime _cacheFecha = DateTime.MinValue;
        // Tiempo de vida de la caché. Si pasa este tiempo desde la última actualización, se recarga la lista.
        private readonly TimeSpan _cacheTTL = TimeSpan.FromMinutes(30);

        // Constructor que permite inyectar un servicio de API opcional; si no se pasa, se crea uno nuevo.
        public MonedaCN(ApiService? api = null)
        {
            _api = api ?? new ApiService();
        }
        // Método privado que asegura que la lista en caché esté cargada y vigente.
        // Si la lista está vacía o la caché expiró, realiza una llamada a la API para actualizarla.
        private async Task EnsureListaAsync(CancellationToken ct = default)
        {
            if (_cacheLista.Count == 0 || DateTime.UtcNow - _cacheFecha > _cacheTTL)
            {
                _cacheLista = await _api.GetCoinListAsync(ct);
                _cacheFecha = DateTime.UtcNow;
            }
        }

        // TODO: Búsqueda directa por ID de la moneda
        // Si el ID es nulo o vacío, retorna null. 
        // De lo contrario, llama a la API para obtener los detalles completos.
        public Task<CoinMarket?> BuscarPorIdAsync(string id, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(id)) return Task.FromResult<CoinMarket?>(null);
            return _api.GetCoinMarketByIdAsync(id.Trim(), "usd", ct);
        }

        // TODO: Búsqueda por Nombre (primero exacto, si no, busca que contenga la cadena)
        // Si el nombre es nulo o vacío, retorna null.
        // Asegura que la lista en caché esté cargada y luego busca el elemento.
        public async Task<CoinMarket?> BuscarPorNombreAsync(string nombre, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return null;
            await EnsureListaAsync(ct);

            var q = nombre.Trim();
            var item = _cacheLista.FirstOrDefault(x => x.name.Equals(q, StringComparison.OrdinalIgnoreCase))
                    ?? _cacheLista.FirstOrDefault(x => x.name.Contains(q, StringComparison.OrdinalIgnoreCase));

            return item != null ? await _api.GetCoinMarketByIdAsync(item.id, "usd", ct) : null;
        }

        //TODO Búsqueda por Símbolo (pueden existir duplicados; se toma el primero)
        public async Task<CoinMarket?> BuscarPorSimboloAsync(string simbolo, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(simbolo)) return null;
            await EnsureListaAsync(ct);

            var q = simbolo.Trim();
            var item = _cacheLista.FirstOrDefault(x => x.symbol.Equals(q, StringComparison.OrdinalIgnoreCase))
                    ?? _cacheLista.FirstOrDefault(x => x.symbol.Contains(q, StringComparison.OrdinalIgnoreCase));

            return item != null ? await _api.GetCoinMarketByIdAsync(item.id, "usd", ct) : null;
        }

        // TODO: Devuelve la lista cacheada para autocompletar, combos, etc.
        // Asegura que la lista esté cargada antes de devolverla..
        public async Task<List<CoinListItem>> ObtenerListaAsync(CancellationToken ct = default)
        {
            await EnsureListaAsync(ct);
            return _cacheLista;
        }
        // Método para limpiar la caché manualmente
        // Borra la lista y reinicia la fecha de actualización.
        public void LimpiarCache()
        {
            _cacheLista.Clear();
            _cacheFecha = DateTime.MinValue;
        }
        // Implementación de IDisposable para liberar recursos del servicio de API
        public void Dispose() => _api.Dispose();

      
    }
}

