
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
        public void ShowMessage(string message)
        {
            if (InvokeRequired) BeginInvoke(new Action(() => listBox1.Items.Add(message)));
            else listBox1.Items.Add(message);
        }

        public void ShowDescription(string description)
        {
            if (InvokeRequired) BeginInvoke(new Action(() => listBox1.Items.Add(description)));
            else listBox1.Items.Add(description);
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
            txtMoneda.Enabled = !isLoading;

            progressBar1.Visible = isLoading;
            if (!isLoading) progressBar1.Value = 0;
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string coin = txtMoneda.Text?.Trim();
            if (!string.IsNullOrEmpty(coin))
                OnRequestDescription?.Invoke(this, coin);
            else
                ShowMessage("⚠ Escribe el id de la moneda (ej: bitcoin).");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(this, EventArgs.Empty);
        }
    };
}
