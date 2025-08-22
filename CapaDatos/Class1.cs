// CapaDatos/CoinModels.cs
namespace CapaDatos
{
    //TODO Lista básica (endpoint /coins/list)
    public class CoinListItem
    {
        public string id { get; set; } = "";
        public string symbol { get; set; } = "";
        public string name { get; set; } = "";
    }

    //TODO Detalle con precio e imagen (endpoint /coins/markets)
    public class CoinMarket
    {
        public string id { get; set; } = "";
        public string symbol { get; set; } = "";
        public string name { get; set; } = "";
        public decimal current_price { get; set; }
        public string image { get; set; } = "";
    }
  
   
}
