
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CapaEntidad;
//using static System.Runtime.InteropServices.JavaScript.JSType;


namespace CapaDatos
{
    public class CoinGeckoChartService
    {
        private readonly HttpClient _httpClient;

        public CoinGeckoChartService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
        }

        public async Task<MarketChartDataModel> GetMarketChartDataAsync(string id, string intervalo)
        {
            string days = "1";

            // Interpretar el intervalo
            if (intervalo == "Minutos")
                days = "1";
            else if (intervalo == "Horas")
                days = "30";
            else if (intervalo == "Días")
                days = "90";

            // URL para info general (nombre, imagen)
            string urlInfo = $"https://api.coingecko.com/api/v3/coins/{id}?localization=false";

            // URL para precios
            string urlChart = $"https://api.coingecko.com/api/v3/coins/{id}/market_chart?vs_currency=usd&days={days}";

            // Obtener info general
            string responseInfo = await _httpClient.GetStringAsync(urlInfo);
            JObject infoJson = JObject.Parse(responseInfo);

            string name = infoJson["name"].ToString();
            string imageUrl = infoJson["image"]["large"].ToString();

            // Obtener precios
            string responseChart = await _httpClient.GetStringAsync(urlChart);
            JObject chartJson = JObject.Parse(responseChart);
            JArray pricesArray = (JArray)chartJson["prices"];

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
