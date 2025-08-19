using CapaDatos;
using CapaNegocio;
using System.Net;
using System.Windows.Forms.DataVisualization.Charting;
using CapaEntidad;

namespace Forns_Descripcion
{
    public partial class Form1 : Form
    {
        private readonly MonedaCN _monedaCN;
        public event EventHandler<(string id, string intervalo)> OnRequestChart;
        public Form1()
        {
            InitializeComponent();
            _monedaCN = new MonedaCN();
            cbIntervalo.Items.AddRange(new[] { "Minutos", "Horas", "Días" });
            cbIntervalo.SelectedIndex = 0;
            lblNombre.Text = "";
           
        }
        public void ShowChart(MarketChartDataModel model)
        {
            lblNombre.Text = model.Name;
            picLogo.Load(model.ImageUrl);

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea("Main"));
            chart1.Series.Add("Precio");
            chart1.Series["Precio"].ChartType = SeriesChartType.Line;

            chart1.ChartAreas.Clear();
            var area = new ChartArea("Main");

            // Ajustar el eje Y automáticamente
            area.AxisY.Minimum = model.DataPoints.Min(p => p.Price) * 0.98; // 2% menos
            area.AxisY.Maximum = model.DataPoints.Max(p => p.Price) * 1.02; // 2% más

            // Estilo opcional para el eje X
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -45;

            chart1.ChartAreas.Add(area);

            foreach (var point in model.DataPoints)
            {
                chart1.Series["Precio"].Points.AddXY(point.Date.ToString("g"), point.Price);
            }
        }

        public void ShowColumnChart(MarketChartDataModel model)
        {
            lblNombre.Text = model.Name;
            picLogo.Load(model.ImageUrl);

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            var area = new ChartArea("ColumnArea");
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.Title = "Fecha y hora";
            area.AxisY.Title = "Precio USD";

            // 🔥 AJUSTE PARA QUE EL EJE Y NO SEA DESPROPORCIONADO
            var puntos = model.DataPoints.Skip(Math.Max(0, model.DataPoints.Count - 10)).ToList();

            double min = puntos.Min(p => p.Price);
            double max = puntos.Max(p => p.Price);

            // Si los valores están muy juntos, ampliamos ligeramente el rango
            if (max - min < 50)
            {
                min -= 10;
                max += 10;
            }

            area.AxisY.Minimum = min;
            area.AxisY.Maximum = max;

            chart1.ChartAreas.Add(area);

            var series = new Series("Precio")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = Color.Gold
            };

            foreach (var point in puntos)
            {
                series.Points.AddXY(point.Date.ToString("g"), point.Price);
            }

            chart1.Series.Add(series);
        }
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
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
        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                var id = txtId.Text.Trim().ToLower();
                var intervalo = cbIntervalo.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(id))
                    OnRequestChart?.Invoke(this, (id, intervalo));
            }
        }
    }
    
}

