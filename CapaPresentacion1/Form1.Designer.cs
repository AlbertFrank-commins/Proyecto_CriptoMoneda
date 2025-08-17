namespace CapaPresentacion1
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
            pictureBox1 = new PictureBox();
            lbl_Nombre = new Label();
            txt_Buscar = new TextBox();
            btn_Buscar = new Button();
            Lbl_Buscar = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(47, 153);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(173, 99);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbl_Nombre
            // 
            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Location = new Point(47, 294);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Size = new Size(43, 17);
            lbl_Nombre.TabIndex = 1;
            lbl_Nombre.Text = "Name";
            // 
            // txt_Buscar
            // 
            txt_Buscar.Location = new Point(47, 90);
            txt_Buscar.Name = "txt_Buscar";
            txt_Buscar.Size = new Size(256, 25);
            txt_Buscar.TabIndex = 2;
            // 
            // btn_Buscar
            // 
            btn_Buscar.Location = new Point(351, 92);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new Size(75, 23);
            btn_Buscar.TabIndex = 3;
            btn_Buscar.Text = "Buscar";
            btn_Buscar.UseVisualStyleBackColor = true;
            // 
            // Lbl_Buscar
            // 
            Lbl_Buscar.AutoSize = true;
            Lbl_Buscar.Location = new Point(47, 43);
            Lbl_Buscar.Name = "Lbl_Buscar";
            Lbl_Buscar.Size = new Size(86, 17);
            Lbl_Buscar.TabIndex = 4;
            Lbl_Buscar.Text = "Busacando.....";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Lbl_Buscar);
            Controls.Add(btn_Buscar);
            Controls.Add(txt_Buscar);
            Controls.Add(lbl_Nombre);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lbl_Nombre;
        private TextBox txt_Buscar;
        private Button btn_Buscar;
        private Label Lbl_Buscar;
    }
}
