using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public interface IGraphView
    {
        event EventHandler<(string id, string intervalo)> OnRequestChart;
        void ShowChart(MarketChartDataModel model);
        void ShowError(string message);
        void ShowColumnChart(MarketChartDataModel model);
    }

    public class MonedaCN
    {
        private readonly CoinGeckoChartService _chartService;

        public MonedaCN()
        {
            _chartService = new CoinGeckoChartService();
        }

        public async Task<MarketChartDataModel> ObtenerGraficoAsync(string id, string intervalo)
        {
            return await _chartService.GetMarketChartDataAsync(id, intervalo);
        }
    }
    public class GraphPresenter
    {
        private readonly IGraphView _view;
        private readonly CoinGeckoChartService _service;

        public GraphPresenter(IGraphView view, CoinGeckoChartService service)
        {
            _view = view;
            _service = service;

            _view.OnRequestChart += async (s, data) =>
            {
                await ObtenerDatos(data.id, data.intervalo);
            };
        }

        private async Task ObtenerDatos(string id, string intervalo)
        {
            try
            {
                var datos = await _service.GetMarketChartDataAsync(id, intervalo);
                _view.ShowColumnChart(datos);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error: {ex.Message}");
            }
        }
    }
}
