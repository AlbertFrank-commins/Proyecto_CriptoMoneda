using CapaPresentacion1;
using Forns_Descripcion;
using Presentacion_Descripcion;
using frmAyuda;

namespace Menu
{
    // TODO: Formulario principal del men� que maneja la navegaci�n entre formularios hijos
    public partial class Form1 : Form
    {
        // TODO: Constructor del formulario principal
        public Form1()
        {
            InitializeComponent(); // TODO: Inicializa los componentes de UI
        }

        // TODO: M�todo para abrir un formulario hijo dentro del panel principal
        private void AbrirFormularioEnPanel(Form formHijo)
        {
            // TODO: Si ya hay un formulario en el panel, lo elimina
            if (PanelApp.Controls.Count > 0)
                PanelApp.Controls.RemoveAt(0);

            // TODO: Configura el formulario hijo para integrarse al panel
            formHijo.TopLevel = false; // No ser� un formulario independiente
            formHijo.FormBorderStyle = FormBorderStyle.None; // Sin borde
            formHijo.Dock = DockStyle.Fill; // Ocupa todo el panel

            // TODO: Agrega el formulario al panel y lo muestra
            PanelApp.Controls.Add(formHijo);
            PanelApp.Tag = formHijo; // Guardar referencia
            formHijo.Show();
        }

        // TODO: Evento click del bot�n "Buscar Moneda"
        // TODO: Abre el formulario frmBuscar dentro del panel
        private void btnBusM_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmBuscar());
        }

        // TODO: Evento click del bot�n "Buscar Gr�fico"
        // TODO: Abre el formulario frmGrafico dentro del panel
        private void btnBusG_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmGrafico());
        }

        // TODO: Evento click del bot�n "Buscar Descripci�n"
        // TODO: Abre el formulario frmDescripcion dentro del panel
        private void btnBusD_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmDescripcion());
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new ());
        }
    }
}


