using System.Net;
using System.Windows.Forms.DataVisualization.Charting;

namespace Forns_Descripcion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _monedaCN = new MonedaCN();
        }
    
     private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtBuscar.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Escribe un ID de moneda (ej: bitcoin)");
                    return;
                }

                var datos = await _monedaCN.ObtenerDatosGrafico(id);

                // Mostrar imagen
                using (var wc = new WebClient())
                {
                    var imgBytes = await wc.DownloadDataTaskAsync(datos.ImageUrl);
                    using (var ms = new System.IO.MemoryStream(imgBytes))
                    {
                        pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                    }
                }

                // Llenar gráfico
                chart1.Series.Clear();
                var serie = new Series(datos.Name)
                {
                    ChartType = SeriesChartType.Line,
                    XValueType = ChartValueType.DateTime
                };

                foreach (var punto in datos.DataPoints)
                {
                    serie.Points.AddXY(punto.Date, punto.Price);
                }

                chart1.Series.Add(serie);
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM HH:mm";
                chart1.ChartAreas[0].RecalculateAxesScale();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos: {ex.Message}");
            }
        }
    }
}
