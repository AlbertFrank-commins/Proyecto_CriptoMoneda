using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    // TODO: Servicio que obtiene datos de gráficos de monedas desde CoinGecko
    public class CoinGeckoChartService
    {
        // TODO: Cliente HTTP para realizar solicitudes a la API
        private readonly HttpClient _httpClient;

        // TODO: Constructor por defecto
        public CoinGeckoChartService()
        {
        }

        // TODO: Constructor que recibe un HttpClient externo
        public CoinGeckoChartService(HttpClient httpClient)
        {
            _httpClient = new HttpClient(); // TODO: Inicializa HttpClient si no se pasa uno
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0"); // TODO: Configura User-Agent
            _httpClient = httpClient; // TODO: Asigna el HttpClient recibido
        }

        // TODO: Obtiene datos del gráfico de precios de una moneda por ID y intervalo
        public async Task<MarketChartDataModel> GetMarketChartDataAsync(string id, string intervalo)
        {
            string days = "1";

            // TODO: Interpreta el intervalo seleccionado por el usuario
            if (intervalo == "Minutos")
                days = "1";
            else if (intervalo == "Horas")
                days = "30";
            else if (intervalo == "Días")
                days = "90";

            // TODO: URL para obtener info general (nombre, imagen)
            string urlInfo = $"https://api.coingecko.com/api/v3/coins/{id}?localization=false";

            // TODO: URL para obtener precios históricos
            string urlChart = $"https://api.coingecko.com/api/v3/coins/{id}/market_chart?vs_currency=usd&days={days}";

            // TODO: Obtener info general desde la API
            string responseInfo = await _httpClient.GetStringAsync(urlInfo);
            JObject infoJson = JObject.Parse(responseInfo);

            string name = infoJson["name"].ToString();                  // TODO: Nombre de la moneda
            string imageUrl = infoJson["image"]["large"].ToString();    // TODO: URL de imagen

            // TODO: Obtener precios históricos desde la API
            string responseChart = await _httpClient.GetStringAsync(urlChart);
            JObject chartJson = JObject.Parse(responseChart);
            JArray pricesArray = (JArray)chartJson["prices"];

            // TODO: Convertir datos a lista de DataPoints
            var dataPoints = new List<DataPoint>();

            foreach (var point in pricesArray)
            {
                long unix = point[0].Value<long>();                        // TODO: Timestamp en milisegundos
                double price = point[1].Value<double>();                   // TODO: Precio en USD
                DateTime date = DateTimeOffset.FromUnixTimeMilliseconds(unix).DateTime; // TODO: Convertir a DateTime

                dataPoints.Add(new DataPoint { Date = date, Price = price }); // TODO: Agregar al listado
            }

            // TODO: Construir y retornar el modelo de datos completo para el gráfico
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
