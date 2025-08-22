
namespace Menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void AbrirFormularioEnPanel(Form formHijo)
         {
             if (PanelApp.Controls.Count > 0)
                 PanelApp.Controls.RemoveAt(0);

             formHijo.TopLevel = false;
             formHijo.FormBorderStyle = FormBorderStyle.None;
             formHijo.Dock = DockStyle.Fill;

             PanelApp.Controls.Add(formHijo);
             PanelApp.Tag = formHijo;

             formHijo.Show();
         }
        
        private void btnBusM_Click(object sender, EventArgs e)
        {

            // AbrirFormularioEnPanel(new ());
           
        }

        private void btnBusG_Click(object sender, EventArgs e)
        {
           // AbrirFormularioEnPanel(new ());
        }
    }
}
    
