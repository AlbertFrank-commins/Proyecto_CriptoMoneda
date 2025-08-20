using CapaEntidad;
namespace InterfazGrafic
{
    public interface IGraphView
    {
        event EventHandler<(string id, string intervalo)> OnRequestChart;
        void ShowChart(MarketChartDataModel model);
        void ShowError(string message);
        void ShowColumnChart(MarketChartDataModel model);
    }
}
