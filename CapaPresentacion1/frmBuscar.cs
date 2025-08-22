// TODO: CapaPresentacion1/Form1.cs
using System.Globalization;
using CapaNegocio;
using CapaDatos;

namespace CapaPresentacion1
{
    // TODO: Formulario para buscar y mostrar información de criptomonedas
    public partial class frmBuscar : Form
    {
        // TODO: Instancia de la capa de negocio que maneja monedas
        private readonly MonedaCN _monedaCN = new MonedaCN();

        // TODO: Constructor del formulario
        public frmBuscar()
        {
            InitializeComponent();

            // TODO: Suscribe eventos de carga del formulario y botones
            this.Load += Form1_Load;
            btn_Buscar.Click += btn_Buscar_Click;
            txt_Buscar.KeyDown += txt_Buscar_KeyDown;
        }

        // TODO: Evento Load del formulario
        // TODO: Precarga la lista de monedas para búsquedas rápidas y limpia la UI
        private async void Form1_Load(object? sender, EventArgs e)
        {
            try
            {
                await _monedaCN.ObtenerListaAsync(); // TODO: Precarga de la lista de monedas (opcional)
            }
            catch
            {
                // TODO: Ignorar errores silenciosamente durante la precarga
            }

            ClearUI(); // TODO: Limpia los controles del formulario
        }

        // TODO: Evento click del botón Buscar
        private async void btn_Buscar_Click(object? sender, EventArgs e)
        {
            await BuscarYMostrarAsync(txt_Buscar.Text);
        }

        // TODO: Evento KeyDown del TextBox de búsqueda
        // TODO: Permite buscar al presionar Enter
        private async void txt_Buscar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // TODO: Evita el "ding" del Enter
                await BuscarYMostrarAsync(txt_Buscar.Text);
            }
        }

        // TODO: Método central que realiza la búsqueda y actualiza la UI
        private async Task BuscarYMostrarAsync(string query)
        {
            query = (query ?? "").Trim();
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Escribe un ID, Nombre o Símbolo."); // TODO: Mensaje si no hay texto
                return;
            }

            try
            {
                ToggleUI(false); // TODO: Desactiva controles mientras se realiza la búsqueda
                ClearUI();       // TODO: Limpia resultados anteriores

                // TODO: Búsqueda jerárquica: primero por ID, luego por Símbolo, finalmente por Nombre
                CoinMarket? coin =
                    await _monedaCN.BuscarPorIdAsync(query)
                    ?? await _monedaCN.BuscarPorSimboloAsync(query)
                    ?? await _monedaCN.BuscarPorNombreAsync(query);

                if (coin == null)
                {
                    MessageBox.Show("No se encontró la criptomoneda."); // TODO: Mensaje si no se encuentra
                    return;
                }

                DisplayResult(coin); // TODO: Muestra los resultados en la UI
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error llamando a la API: {ex.Message}"); // TODO: Manejo de errores HTTP
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}"); // TODO: Manejo de errores generales
            }
            finally
            {
                ToggleUI(true); // TODO: Reactiva controles al finalizar
            }
        }

        // TODO: Método que muestra los datos de la moneda en la UI
        private void DisplayResult(CoinMarket model)
        {
            lbl_Id.Text = model.id;
            //lblNombre.Text = model.name; // TODO: Comentado pero se puede habilitar
            lblSimbolo.Text = model.symbol.ToUpperInvariant();
            lblPrecio.Text = model.current_price.ToString("C2", CultureInfo.GetCultureInfo("en-US"));

            if (!string.IsNullOrWhiteSpace(model.image))
                pictureBox1.LoadAsync(model.image); // TODO: Carga la imagen asincrónicamente
            else
                pictureBox1.Image = null;           // TODO: Si no hay imagen, limpia el control
        }

        // TODO: Método que limpia todos los controles de resultados
        private void ClearUI()
        {
            lbl_Id.Text = "-";
            //lblNombre.Text = "-"; // TODO: Comentado pero se puede habilitar
            lblSimbolo.Text = "-";
            lblPrecio.Text = "-";
            pictureBox1.Image = null;
        }

        // TODO: Método que activa/desactiva los controles y cambia el cursor
        private void ToggleUI(bool enabled)
        {
            btn_Buscar.Enabled = enabled;
            txt_Buscar.Enabled = enabled;
            Cursor = enabled ? Cursors.Default : Cursors.WaitCursor;
        }
    }
}
