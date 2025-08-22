namespace Presentacion_Descripcion
{
    partial class frmDescripcion
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
            textBox1 = new TextBox();
            btnBuscar = new Button();
            btnEliminar = new Button();
            listBox1 = new ListBox();
            txtMoneda = new Label();
            progressBar1 = new ProgressBar();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(54, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(428, 25);
            textBox1.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.Location = new Point(507, 31);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(112, 32);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(634, 31);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 32);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Cancelar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            listBox1.ForeColor = SystemColors.MenuText;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(48, 158);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(704, 256);
            listBox1.TabIndex = 3;
            // 
            // txtMoneda
            // 
            txtMoneda.AutoSize = true;
            txtMoneda.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMoneda.Location = new Point(736, 95);
            txtMoneda.Name = "txtMoneda";
            txtMoneda.Size = new Size(10, 13);
            txtMoneda.TabIndex = 4;
            txtMoneda.Text = ".";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(48, 111);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(704, 23);
            progressBar1.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(48, 450);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(752, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(48, 450);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(48, 450);
            panel3.TabIndex = 7;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(48, 421);
            panel4.Name = "panel4";
            panel4.Size = new Size(704, 29);
            panel4.TabIndex = 8;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(48, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(704, 32);
            panel5.TabIndex = 9;
            // 
            // frmDescripcion
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(progressBar1);
            Controls.Add(txtMoneda);
            Controls.Add(listBox1);
            Controls.Add(btnEliminar);
            Controls.Add(btnBuscar);
            Controls.Add(textBox1);
            Name = "frmDescripcion";
            Text = "Form1";
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btnBuscar;
        private Button btnEliminar;
        private ListBox listBox1;
        private Label txtMoneda;
        private ProgressBar progressBar1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}
