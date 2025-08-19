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
            lbl_Id = new Label();
            txt_Buscar = new TextBox();
            btn_Buscar = new Button();
            Lbl_Buscar = new Label();
            lblSimbolo = new Label();
            lblPrecio = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(368, 127);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(358, 284);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbl_Id
            // 
            lbl_Id.AutoSize = true;
            lbl_Id.Location = new Point(66, 127);
            lbl_Id.Name = "lbl_Id";
            lbl_Id.Size = new Size(43, 17);
            lbl_Id.TabIndex = 1;
            lbl_Id.Text = "Name";
            // 
            // txt_Buscar
            // 
            txt_Buscar.Location = new Point(66, 70);
            txt_Buscar.Name = "txt_Buscar";
            txt_Buscar.Size = new Size(256, 25);
            txt_Buscar.TabIndex = 2;
            // 
            // btn_Buscar
            // 
            btn_Buscar.Location = new Point(368, 70);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new Size(75, 23);
            btn_Buscar.TabIndex = 3;
            btn_Buscar.Text = "Buscar";
            btn_Buscar.UseVisualStyleBackColor = true;
            // 
            // Lbl_Buscar
            // 
            Lbl_Buscar.AutoSize = true;
            Lbl_Buscar.Location = new Point(90, 37);
            Lbl_Buscar.Name = "Lbl_Buscar";
            Lbl_Buscar.Size = new Size(86, 17);
            Lbl_Buscar.TabIndex = 4;
            Lbl_Buscar.Text = "Busacando.....";
            // 
            // lblSimbolo
            // 
            lblSimbolo.AutoSize = true;
            lblSimbolo.Location = new Point(66, 171);
            lblSimbolo.Name = "lblSimbolo";
            lblSimbolo.Size = new Size(56, 17);
            lblSimbolo.TabIndex = 5;
            lblSimbolo.Text = "Simbolo";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(66, 217);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(44, 17);
            lblPrecio.TabIndex = 6;
            lblPrecio.Text = "Precio";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPrecio);
            Controls.Add(lblSimbolo);
            Controls.Add(Lbl_Buscar);
            Controls.Add(btn_Buscar);
            Controls.Add(txt_Buscar);
            Controls.Add(lbl_Id);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lbl_Id;
        private TextBox txt_Buscar;
        private Button btn_Buscar;
        private Label Lbl_Buscar;
        private Label lblSimbolo;
        private Label lblPrecio;
    }
}
