// CapaDatos/CoinModels.cs
namespace CapaDatos
{
    // Lista básica (endpoint /coins/list)
    public class CoinListItem
    {
        public string id { get; set; } = "";
        public string symbol { get; set; } = "";
        public string name { get; set; } = "";
    }

    // Detalle con precio e imagen (endpoint /coins/markets)
    public class CoinMarket
    {
        public string id { get; set; } = "";
        public string symbol { get; set; } = "";
        public string name { get; set; } = "";
        public decimal current_price { get; set; }
        public string image { get; set; } = "";
    }
    // json de Los Graficos
    public class MarketChartDataModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<DataPoint> DataPoints { get; set; } = new();
    }

    public class DataPoint
    {
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
