using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    public class MarketChartDataModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<DataPoint> DataPoints { get; set; }
    }

    public class DataPoint
    {
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
    public class Candle
    {
        public DateTime Time { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
    }
   


}
