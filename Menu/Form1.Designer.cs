namespace Menu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            PanelMenu = new Panel();
            btnAyuda = new Button();
            btnBusD = new Button();
            btnBusG = new Button();
            btnBusM = new Button();
            label1 = new Label();
            PanelLogo = new Panel();
            pcLogo = new PictureBox();
            PanelApp = new Panel();
            PanelMenu.SuspendLayout();
            PanelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcLogo).BeginInit();
            SuspendLayout();
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = Color.Turquoise;
            PanelMenu.Controls.Add(btnAyuda);
            PanelMenu.Controls.Add(btnBusD);
            PanelMenu.Controls.Add(btnBusG);
            PanelMenu.Controls.Add(btnBusM);
            PanelMenu.Controls.Add(label1);
            PanelMenu.Controls.Add(PanelLogo);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(169, 547);
            PanelMenu.TabIndex = 0;
            // 
            // btnAyuda
            // 
            btnAyuda.Dock = DockStyle.Top;
            btnAyuda.FlatAppearance.BorderSize = 0;
            btnAyuda.FlatStyle = FlatStyle.Flat;
            btnAyuda.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAyuda.Location = new Point(0, 366);
            btnAyuda.Name = "btnAyuda";
            btnAyuda.Size = new Size(169, 84);
            btnAyuda.TabIndex = 3;
            btnAyuda.Text = "AYUDA";
            btnAyuda.UseVisualStyleBackColor = true;
            btnAyuda.Click += btnAyuda_Click;
            // 
            // btnBusD
            // 
            btnBusD.Dock = DockStyle.Top;
            btnBusD.FlatAppearance.BorderSize = 0;
            btnBusD.FlatStyle = FlatStyle.Flat;
            btnBusD.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBusD.Image = (Image)resources.GetObject("btnBusD.Image");
            btnBusD.ImageAlign = ContentAlignment.MiddleLeft;
            btnBusD.Location = new Point(0, 277);
            btnBusD.Name = "btnBusD";
            btnBusD.Size = new Size(169, 89);
            btnBusD.TabIndex = 2;
            btnBusD.Text = "             Descripcion";
            btnBusD.UseVisualStyleBackColor = true;
            btnBusD.Click += btnBusD_Click;
            // 
            // btnBusG
            // 
            btnBusG.Dock = DockStyle.Top;
            btnBusG.FlatAppearance.BorderSize = 0;
            btnBusG.FlatStyle = FlatStyle.Flat;
            btnBusG.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBusG.Image = (Image)resources.GetObject("btnBusG.Image");
            btnBusG.ImageAlign = ContentAlignment.MiddleLeft;
            btnBusG.Location = new Point(0, 184);
            btnBusG.Name = "btnBusG";
            btnBusG.Size = new Size(169, 93);
            btnBusG.TabIndex = 1;
            btnBusG.Text = "         Grafico";
            btnBusG.UseVisualStyleBackColor = true;
            btnBusG.Click += btnBusG_Click;
            // 
            // btnBusM
            // 
            btnBusM.Dock = DockStyle.Top;
            btnBusM.FlatAppearance.BorderSize = 0;
            btnBusM.FlatStyle = FlatStyle.Flat;
            btnBusM.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBusM.ForeColor = SystemColors.ActiveCaptionText;
            btnBusM.Image = (Image)resources.GetObject("btnBusM.Image");
            btnBusM.ImageAlign = ContentAlignment.MiddleLeft;
            btnBusM.Location = new Point(0, 91);
            btnBusM.Name = "btnBusM";
            btnBusM.Size = new Size(169, 93);
            btnBusM.TabIndex = 0;
            btnBusM.Text = "         Buscar";
            btnBusM.UseVisualStyleBackColor = true;
            btnBusM.Click += btnBusM_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 85);
            label1.Name = "label1";
            label1.Size = new Size(182, 15);
            label1.TabIndex = 0;
            label1.Text = "___________________________________";
            // 
            // PanelLogo
            // 
            PanelLogo.Controls.Add(pcLogo);
            PanelLogo.Dock = DockStyle.Top;
            PanelLogo.Location = new Point(0, 0);
            PanelLogo.Name = "PanelLogo";
            PanelLogo.Size = new Size(169, 91);
            PanelLogo.TabIndex = 0;
            // 
            // pcLogo
            // 
            pcLogo.Image = (Image)resources.GetObject("pcLogo.Image");
            pcLogo.Location = new Point(0, 0);
            pcLogo.Name = "pcLogo";
            pcLogo.Size = new Size(169, 91);
            pcLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pcLogo.TabIndex = 0;
            pcLogo.TabStop = false;
            // 
            // PanelApp
            // 
            PanelApp.BackColor = Color.LightGray;
            PanelApp.Dock = DockStyle.Fill;
            PanelApp.Location = new Point(169, 0);
            PanelApp.Name = "PanelApp";
            PanelApp.Size = new Size(782, 547);
            PanelApp.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 547);
            Controls.Add(PanelApp);
            Controls.Add(PanelMenu);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Name = "Form1";
            Text = "Form1";
            PanelMenu.ResumeLayout(false);
            PanelMenu.PerformLayout();
            PanelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMenu;
        private Panel PanelLogo;
        private PictureBox pcLogo;
        private Panel PanelApp;
        private Label label1;
        private Button btnBusM;
        private Button btnBusD;
        private Button btnBusG;
        private Button btnAyuda;
    }
}
