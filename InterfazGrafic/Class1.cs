using CapaEntidad;

namespace InterfazGrafic
{
    // TODO: Interfaz que define el contrato para una vista que muestra gráficos de criptomonedas
    public interface IGraphView
    {
        // TODO: Evento que se dispara cuando el usuario solicita un gráfico.
        // TODO: Devuelve una tupla con el ID de la moneda y el intervalo de tiempo del gráfico
        event EventHandler<(string id, string intervalo)> OnRequestChart;

        // TODO: Muestra un gráfico de línea o de área en la vista según los datos del modelo
        void ShowChart(MarketChartDataModel model);

        // TODO: Muestra un mensaje de error en la vista
        void ShowError(string message);

        // TODO: Muestra un gráfico de columnas en la vista según los datos del modelo
        void ShowColumnChart(MarketChartDataModel model);
    }
}

