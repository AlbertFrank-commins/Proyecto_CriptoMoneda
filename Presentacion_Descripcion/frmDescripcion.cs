using System.Windows.Forms;

namespace Presentacion_Descripcion
{
    // TODO: Formulario que muestra la descripción de una criptomoneda
    // TODO: Implementa la interfaz ICoinDescriptionView para comunicación con el presentador
    public partial class frmDescripcion : Form, ICoinDescriptionView
    {
        // TODO: Evento que se dispara cuando se solicita la descripción de una moneda
        public event EventHandler<string> OnRequestDescription;

        // TODO: Evento que se dispara cuando se cancela la operación
        public event EventHandler OnCancel;

        // TODO: Presentador que maneja la lógica entre la vista y el servicio
        private CoinDescriptionPresenter _presenter;

        // TODO: Constructor del formulario
        public frmDescripcion()
        {
            InitializeComponent();

            // TODO: Configura el progress bar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Visible = false;

            // TODO: Crea el servicio HTTP y el servicio de CoinGecko
            var http = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
            var service = new CoinGeckoDescriptionService(http);

            // TODO: Inicializa el presentador con la vista y el servicio
            _presenter = new CoinDescriptionPresenter(this, service);
        }

        // TODO: Muestra la descripción de la moneda en el ListBox
        public async void ShowDescription(string description)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ShowDescription(description)));
                return;
            }

            // TODO: Espera un breve delay para mejorar la experiencia visual
            await Task.Delay(700);

            listBox1.Items.Add("📄 Descripción:");

            // TODO: Divide el texto largo en líneas de máximo 80 caracteres
            int lineLength = 80;
            for (int i = 0; i < description.Length; i += lineLength)
            {
                string line = (i + lineLength > description.Length)
                    ? description.Substring(i)
                    : description.Substring(i, lineLength);

                listBox1.Items.Add(line);
            }

            listBox1.Items.Add(""); // TODO: Línea vacía para separar de la próxima búsqueda
        }

        // TODO: Muestra un mensaje en el ListBox
        public void ShowMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ShowMessage(message)));
                return;
            }

            listBox1.Items.Add("💬 " + message);
            listBox1.Items.Add(""); // TODO: Línea vacía para separar mensajes
        }

        // TODO: Actualiza el valor del progress bar
        public void UpdateProgress(int value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                    progressBar1.Value = Math.Max(progressBar1.Minimum, Math.Min(value, progressBar1.Maximum))));
            }
            else
            {
                progressBar1.Value = Math.Max(progressBar1.Minimum, Math.Min(value, progressBar1.Maximum));
            }
        }

        // TODO: Activa o desactiva controles y muestra el progress bar según isLoading
        public void ToggleLoading(bool isLoading)
        {
            if (InvokeRequired) { BeginInvoke(new Action(() => ToggleLoading(isLoading))); return; }

            btnBuscar.Enabled = !isLoading;
            btnEliminar.Enabled = isLoading;
            textBox1.Enabled = !isLoading;

            progressBar1.Visible = isLoading;
            if (!isLoading) progressBar1.Value = 0;
        }

        // TODO: Evento click del botón Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string coin = textBox1.Text?.Trim().ToLower();
            if (!string.IsNullOrEmpty(coin))
                OnRequestDescription?.Invoke(this, coin); // TODO: Dispara evento para obtener descripción
            else
                ShowMessage("⚠ Escribe el id de la moneda (ej: bitcoin).");

            listBox1.Items.Clear(); // TODO: Limpia resultados previos antes de mostrar nuevos
        }

        // TODO: Evento click del botón Eliminar (cancelar)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(this, EventArgs.Empty); // TODO: Dispara evento de cancelación
        }
    };
}

