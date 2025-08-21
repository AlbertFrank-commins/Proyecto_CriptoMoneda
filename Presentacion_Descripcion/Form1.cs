
using System.Windows.Forms;

namespace Presentacion_Descripcion
{
    public partial class Form1 : Form, ICoinDescriptionView
    {
        public event EventHandler<string> OnRequestDescription;
        public event EventHandler OnCancel;

        private CoinDescriptionPresenter _presenter;
        public Form1()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Visible = false;

            var http = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
            var service = new CoinGeckoDescriptionService(http);
            _presenter = new CoinDescriptionPresenter(this, service);

        }
        public async void ShowDescription(string description)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ShowDescription(description)));
                return;
            }
            await Task.Delay(700); 
            listBox1.Items.Add("📄 Descripción:");

            // Dividir el texto en líneas más pequeñas si es muy largo
            int lineLength = 80; // caracteres por línea
            for (int i = 0; i < description.Length; i += lineLength)
            {
                string line = (i + lineLength > description.Length)
                    ? description.Substring(i)
                    : description.Substring(i, lineLength);
                listBox1.Items.Add(line);
            }

            listBox1.Items.Add(""); // línea vacía para separar de la próxima búsqueda
            
        }

        public void ShowMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ShowMessage(message)));
                return;
            }

            listBox1.Items.Add("💬 " + message);
            listBox1.Items.Add(""); // línea vacía para separar
        }

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

        public void ToggleLoading(bool isLoading)
        {
            if (InvokeRequired) { BeginInvoke(new Action(() => ToggleLoading(isLoading))); return; }

            btnBuscar.Enabled = !isLoading;
            btnEliminar.Enabled = isLoading;
            textBox1.Enabled = !isLoading;

            progressBar1.Visible = isLoading;
            if (!isLoading) progressBar1.Value = 0;
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string coin = textBox1.Text?.Trim().ToLower();
            if (!string.IsNullOrEmpty(coin))
                OnRequestDescription?.Invoke(this, coin);
            else
                ShowMessage("⚠ Escribe el id de la moneda (ej: bitcoin).");
            listBox1.Items.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(this, EventArgs.Empty);
        }
    };
}
