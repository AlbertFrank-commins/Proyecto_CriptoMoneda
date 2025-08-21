using CapaDatos;
using CapaNegocio;
using System.Net;
using System.Windows.Forms.DataVisualization.Charting;
using CapaEntidad;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Forns_Descripcion
{
    public partial class Form1 : Form, IGraphView
    {
        private readonly MonedaCN _monedaCN;
        private SeriesChartType chartType;

        public event EventHandler<(string id, string intervalo)> OnRequestChart;

        public Form1()
        {
            InitializeComponent();
            var service = new CoinGeckoChartService(new HttpClient());
            var presenter = new GraphPresenter(this, service);
            cbIntervalo.Items.AddRange(new[] { "Minutos", "Horas", "Días" });
            cbIntervalo.SelectedIndex = 0;
            lblNombre.Text = "";
            //btnBuscar.Visible = false;

        }

        public void ShowChart(MarketChartDataModel model)
        {
            lblNombre.Text = model.Name;
            picLogo.Load(model.ImageUrl);

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            var area = new ChartArea("Main");

            // Ajustar el eje Y automáticamente
            area.AxisY.Minimum = model.DataPoints.Min(p => p.Price) * 0.98;
            area.AxisY.Maximum = model.DataPoints.Max(p => p.Price) * 1.02;

            // Estilo opcional para el eje X
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -45;

            chart1.ChartAreas.Add(area);

            var series = new Series("Precio")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = Color.Gold
            };

            foreach (var point in model.DataPoints)
            {
                series.Points.AddXY(point.Date.ToString("g"), point.Price);
            }

            chart1.Series.Add(series);
        }


        public void ShowColumnChart(MarketChartDataModel model)
        {
            // Header
            lblNombre.Text = model?.Name ?? "—";
            try
            {
                // Cargar por URL sin bloquear el UI
                picLogo.ImageLocation = model?.ImageUrl;
            }
            catch { /* Ignorar errores de carga */ }

            // Guard: datos vacíos
            if (model?.DataPoints == null || model.DataPoints.Count == 0)
            {
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Titles.Clear();
                chart1.Titles.Add("Sin datos para mostrar");
                return;
            }

            // Reset
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();

            // Leyenda
            var legend = new Legend { Docking = Docking.Top, Enabled = true };
            chart1.Legends.Add(legend);

            // Área
            var area = new ChartArea("Main");
            chart1.ChartAreas.Add(area);

            // Eje X como fechas reales (mejor escalado y etiquetas)
            area.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.LabelStyle.Format = "dd/MM HH:mm"; // adapta a tu preferencia
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.Title = "Fecha y hora";

            // Eje Y
            area.AxisY.MajorGrid.Enabled = true;
            area.AxisY.Title = "Precio USD";

            // Serie
            var series = new Series("Precio")
            {
                ChartType = chartType,
                BorderWidth = 2,
                Color = Color.Gold,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                IsValueShownAsLabel = chartType == SeriesChartType.Column // etiquetas visibles sólo en columnas
            };

            // Tooltips
            series.ToolTip = "Fecha: #VALX{dd/MM/yyyy HH:mm}\nPrecio: #VALY USD";

            // Datos: usar DateTime como X directamente
            foreach (var p in model.DataPoints.OrderBy(d => d.Date))
                series.Points.AddXY(p.Date, p.Price);

            chart1.Series.Add(series);

            // Título
            chart1.Titles.Add($"{model.Name} - Evolución del precio");

            // Escalado Y automático con pequeño padding si los precios son muy parecidos
            double min = model.DataPoints.Min(p => p.Price);
            double max = model.DataPoints.Max(p => p.Price);

            if (Math.Abs(max - min) < 1e-9)
            {
                // Todos iguales: abre banda simétrica
                area.AxisY.Minimum = min - 1;
                area.AxisY.Maximum = max + 1;
            }
            else
            {
                // Padding del 2%
                double pad = (max - min) * 0.02;
                area.AxisY.Minimum = min - pad;
                area.AxisY.Maximum = max + pad;
            }

            // Para líneas, puedes suavizar un poco la curva (opcional)
            if (chartType == SeriesChartType.Line)
            {
                series["LineTension"] = "0.3"; // 0..1 (curva suavizada)
                series.BorderDashStyle = ChartDashStyle.Solid;
            }

            // Recalcular por si el control necesita ajustar algo tras añadir puntos
            area.RecalculateAxesScale();
        }



        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       
       /* private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                var id = txtId.Text.Trim().ToLower();
                var intervalo = cbIntervalo.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(id))
                    OnRequestChart?.Invoke(this, (id, intervalo));
            }
        }*/


        private async void Form1_Load(object sender, EventArgs e)
        {

            // Solo configuración inicial, nada de Bitcoin aquí
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM HH:mm";
        }

        private void btn_Buscar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtId.Text) && cbIntervalo.SelectedItem != null)
            {
                var id = txtId.Text.Trim().ToLower(); // para que sea más flexible
                var intervalo = cbIntervalo.SelectedItem.ToString();

                // Lanza el evento que maneja el presenter
                OnRequestChart?.Invoke(this, (id, intervalo));
            }
            else
            {
                ShowError("Por favor, completa el ID de la moneda y selecciona un intervalo.");
            }
        }
    }

}