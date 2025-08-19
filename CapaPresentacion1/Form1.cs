// CapaPresentacion1/Form1.cs
using System.Globalization;
using CapaNegocio;
using CapaDatos;

namespace CapaPresentacion1
{
    public partial class Form1 : Form
    {
        private readonly MonedaCN _monedaCN = new MonedaCN();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            btn_Buscar.Click += btn_Buscar_Click;
            txt_Buscar.KeyDown += txt_Buscar_KeyDown;
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            // Precarga para búsquedas por nombre/símbolo (opcional)
            try { await _monedaCN.ObtenerListaAsync(); } catch { /* silencioso */ }
            ClearUI();
        }

        private async void btn_Buscar_Click(object? sender, EventArgs e)
        {
            await BuscarYMostrarAsync(txt_Buscar.Text);
        }

        private async void txt_Buscar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await BuscarYMostrarAsync(txt_Buscar.Text);
            }
        }

        private async Task BuscarYMostrarAsync(string query)
        {
            query = (query ?? "").Trim();
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Escribe un ID, Nombre o Símbolo.");
                return;
            }

            try
            {
                ToggleUI(false);
                ClearUI();

                // 1) Intentar como ID, 2) como Símbolo, 3) como Nombre
                CoinMarket? coin =
                    await _monedaCN.BuscarPorIdAsync(query)
                    ?? await _monedaCN.BuscarPorSimboloAsync(query)
                    ?? await _monedaCN.BuscarPorNombreAsync(query);

                if (coin == null)
                {
                    MessageBox.Show("No se encontró la criptomoneda.");
                    return;
                }

                DisplayResult(coin);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error llamando a la API: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
            finally
            {
                ToggleUI(true);
            }
        }

        private void DisplayResult(CoinMarket model)
        {
            lbl_Id.Text = model.id;
            //lblNombre.Text = model.name;
            lblSimbolo.Text = model.symbol.ToUpperInvariant();
            lblPrecio.Text = model.current_price.ToString("C2", CultureInfo.GetCultureInfo("en-US"));

            if (!string.IsNullOrWhiteSpace(model.image))
                pictureBox1.LoadAsync(model.image);
            else
                pictureBox1.Image = null;
        }

        private void ClearUI()
        {
            lbl_Id.Text = "-";
            //lblNombre.Text = "-";
            lblSimbolo.Text = "-";
            lblPrecio.Text = "-";
            pictureBox1.Image = null;
        }

        private void ToggleUI(bool enabled)
        {
            btn_Buscar.Enabled = enabled;
            txt_Buscar.Enabled = enabled;
            Cursor = enabled ? Cursors.Default : Cursors.WaitCursor;
        }
    }
}
