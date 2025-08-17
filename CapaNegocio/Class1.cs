using ApiRest;
using CapaDatos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class MonedaCN
    {
        private readonly ApiService _apiService;
        private List<Root> _cacheMonedas; // Para guardar la lista y no llamar a la API cada vez

        public MonedaCN()
        {
            _apiService = new ApiService();
            _cacheMonedas = new List<Root>();
        }

   
        // Obtiene todas las monedas desde la API y las guarda en memoria
      
        public async Task<List<Root>> ObtenerMonedas()
        {
            _cacheMonedas = await _apiService.GetMonedasAsync();
            return _cacheMonedas;
        }

       
        // Busca monedas cuyo nombre contenga el texto dado
    
        public List<Root> BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return _cacheMonedas;

            return _cacheMonedas
                .Where(m => m.name.ToLower().Contains(nombre.ToLower()))
                .ToList();
        }

      
        // Filtra monedas por símbolo exacto
      
        public List<Root> FiltrarPorSimbolo(string simbolo)
        {
            if (string.IsNullOrWhiteSpace(simbolo)) return _cacheMonedas;

            return _cacheMonedas
                .Where(m => m.symbol.ToLower() == simbolo.ToLower())
                .ToList();
        }

        
        // Limpia y devuelve la lista completa (reset)
    
        public List<Root> Limpiar()
        {
            return _cacheMonedas;
        }
    }
}


