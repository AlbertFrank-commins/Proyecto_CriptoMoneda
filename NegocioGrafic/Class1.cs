using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    // TODO: Interfaz que define el contrato para una vista que muestra gráficos de criptomonedas
    public interface IGraphView
    {
        // TODO: Evento que se dispara cuando el usuario solicita un gráfico
        // TODO: Devuelve una tupla con el ID de la moneda y el intervalo de tiempo del gráfico
        event EventHandler<(string id, string intervalo)> OnRequestChart;

        // TODO: Muestra un gráfico de línea o área en la vista
        void ShowChart(MarketChartDataModel model);

        // TODO: Muestra un mensaje de error en la vista
        void ShowError(string message);

        // TODO: Muestra un gráfico de columnas en la vista
        void ShowColumnChart(MarketChartDataModel model);
    }

    // TODO: Clase de negocio para obtener datos de criptomonedas relacionados con gráficos
    public class MonedaCN
    {
        // TODO: Servicio que obtiene los datos de los gráficos desde CoinGecko
        private readonly CoinGeckoChartService _chartService;

        // TODO: Constructor que inicializa el servicio de gráficos
        public MonedaCN()
        {
            _chartService = new CoinGeckoChartService();
        }

        // TODO: Método asincrónico que obtiene los datos de un gráfico según ID de moneda y intervalo
        public async Task<MarketChartDataModel> ObtenerGraficoAsync(string id, string intervalo)
        {
            return await _chartService.GetMarketChartDataAsync(id, intervalo);
        }
    }

    // TODO: Presentador que maneja la lógica entre la vista de gráficos y el servicio de datos
    public class GraphPresenter
    {
        // TODO: Vista que implementa IGraphView
        private readonly IGraphView _view;

        // TODO: Servicio para obtener los datos de los gráficos
        private readonly CoinGeckoChartService _service;

        // TODO: Constructor que recibe la vista y el servicio
        public GraphPresenter(IGraphView view, CoinGeckoChartService service)
        {
            _view = view;
            _service = service;

            // TODO: Suscribe el evento de la vista para recibir solicitudes de gráficos
            _view.OnRequestChart += async (s, data) =>
            {
                await ObtenerDatos(data.id, data.intervalo);
            };
        }

        // TODO: Método privado que obtiene los datos del gráfico de manera asincrónica
        private async Task ObtenerDatos(string id, string intervalo)
        {
            try
            {
                // TODO: Llama al servicio para obtener los datos
                var datos = await _service.GetMarketChartDataAsync(id, intervalo);

                // TODO: Muestra el gráfico de columnas en la vista
                _view.ShowColumnChart(datos);
            }
            catch (Exception ex)
            {
                // TODO: Maneja errores inesperados y los muestra en la vista
                _view.ShowError($"Error: {ex.Message}");
            }
        }
    }
}

