using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Forns_Descripcion
{
    // TODO: Formulario que muestra gráficos de criptomonedas
    // TODO: Implementa la interfaz IGraphView para comunicación con el presentador
    public partial class frmGrafico : Form, IGraphView
    {
        // TODO: Capa de negocio que obtiene los datos de las monedas
        private readonly MonedaCN _monedaCN;

        // TODO: Tipo de gráfico a mostrar (Line, Column, etc.)
        private SeriesChartType chartType;

        // TODO: Evento que se dispara cuando el usuario solicita un gráfico
        public event EventHandler<(string id, string intervalo)> OnRequestChart;

        // TODO: Constructor del formulario
        public frmGrafico()
        {
            InitializeComponent();

            // TODO: Inicializa el servicio HTTP y el presenter
            var service = new CoinGeckoChartService(new HttpClient());
            var presenter = new GraphPresenter(this, service);

            // TODO: Configura el ComboBox de intervalos
            cbIntervalo.Items.AddRange(new[] { "Minutos", "Horas", "Días" });
            cbIntervalo.SelectedIndex = 0;

            // TODO: Inicializa labels y botones (UI limpia)
            lblNombre.Text = "";
            //btnBuscar.Visible = false; // opcional
        }

        // TODO: Muestra un gráfico de línea simple usando los datos del modelo
        public void ShowChart(MarketChartDataModel model)
        {
            lblNombre.Text = model.Name;
            picLogo.Load(model.ImageUrl);

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            var area = new ChartArea("Main");

            // TODO: Ajusta el eje Y automáticamente con un pequeño padding
            area.AxisY.Minimum = model.DataPoints.Min(p => p.Price) * 0.98;
            area.AxisY.Maximum = model.DataPoints.Max(p => p.Price) * 1.02;

            // TODO: Configura eje X (intervalos y ángulo de etiquetas)
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -45;

            chart1.ChartAreas.Add(area);

            // TODO: Crea la serie de datos (línea)
            var series = new Series("Precio")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = Color.Gold
            };

            // TODO: Agrega puntos al gráfico
            foreach (var point in model.DataPoints)
            {
                series.Points.AddXY(point.Date.ToString("g"), point.Price);
            }

            chart1.Series.Add(series);
        }

        // TODO: Muestra un gráfico de columnas o líneas más completo y estilizado
        public void ShowColumnChart(MarketChartDataModel model)
        {
            // TODO: Header
            lblNombre.Text = model?.Name ?? "—";
            try
            {
                picLogo.ImageLocation = model?.ImageUrl; // TODO: Carga imagen sin bloquear UI
            }
            catch { /* Ignorar errores de carga */ }

            // TODO: Validación de datos vacíos
            if (model?.DataPoints == null || model.DataPoints.Count == 0)
            {
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Titles.Clear();
                chart1.Titles.Add("Sin datos para mostrar");
                return;
            }

            // TODO: Reset de gráfico
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();

            // TODO: Leyenda
            var legend = new Legend { Docking = Docking.Top, Enabled = true };
            chart1.Legends.Add(legend);

            // TODO: Área principal del gráfico
            var area = new ChartArea("Main");
            chart1.ChartAreas.Add(area);

            // TODO: Configura eje X como fechas reales
            area.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.LabelStyle.Format = "dd/MM HH:mm";
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.Title = "Fecha y hora";

            // TODO: Eje Y
            area.AxisY.MajorGrid.Enabled = true;
            area.AxisY.Title = "Precio USD";

            // TODO: Configura serie
            var series = new Series("Precio")
            {
                ChartType = chartType,
                BorderWidth = 2,
                Color = Color.Gold,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                IsValueShownAsLabel = chartType == SeriesChartType.Column
            };

            // TODO: Tooltips
            series.ToolTip = "Fecha: #VALX{dd/MM/yyyy HH:mm}\nPrecio: #VALY USD";

            // TODO: Agrega puntos al gráfico
            foreach (var p in model.DataPoints.OrderBy(d => d.Date))
                series.Points.AddXY(p.Date, p.Price);

            chart1.Series.Add(series);

            // TODO: Título del gráfico
            chart1.Titles.Add($"{model.Name} - Evolución del precio");

            // TODO: Escalado automático Y con padding
            double min = model.DataPoints.Min(p => p.Price);
            double max = model.DataPoints.Max(p => p.Price);

            if (Math.Abs(max - min) < 1e-9)
            {
                area.AxisY.Minimum = min - 1;
                area.AxisY.Maximum = max + 1;
            }
            else
            {
                double pad = (max - min) * 0.02;
                area.AxisY.Minimum = min - pad;
                area.AxisY.Maximum = max + pad;
            }

            // TODO: Suavizado opcional para líneas
            if (chartType == SeriesChartType.Line)
            {
                series["LineTension"] = "0.3";
                series.BorderDashStyle = ChartDashStyle.Solid;
            }

            // TODO: Recalcula ejes
            area.RecalculateAxesScale();
        }

        // TODO: Muestra un mensaje de error mediante MessageBox
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // TODO: Configuración inicial al cargar el formulario
        private async void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM HH:mm";
        }

        // TODO: Evento click del botón Buscar
        private void btn_Buscar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtId.Text) && cbIntervalo.SelectedItem != null)
            {
                var id = txtId.Text.Trim().ToLower();
                var intervalo = cbIntervalo.SelectedItem.ToString();

                // TODO: Dispara evento que el presenter escuchará
                OnRequestChart?.Invoke(this, (id, intervalo));
            }
            else
            {
                ShowError("Por favor, completa el ID de la moneda y selecciona un intervalo.");
            }
        }
    }
}

