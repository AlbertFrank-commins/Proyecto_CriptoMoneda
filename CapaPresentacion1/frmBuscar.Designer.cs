namespace CapaPresentacion1
{
    partial class frmBuscar
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
            lblSimbolo = new Label();
            lblPrecio = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(331, 96);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(383, 302);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbl_Id
            // 
            lbl_Id.AutoSize = true;
            lbl_Id.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_Id.ForeColor = Color.Black;
            lbl_Id.Location = new Point(77, 151);
            lbl_Id.Name = "lbl_Id";
            lbl_Id.Size = new Size(53, 21);
            lbl_Id.TabIndex = 1;
            lbl_Id.Text = "Name";
            // 
            // txt_Buscar
            // 
            txt_Buscar.Location = new Point(66, 44);
            txt_Buscar.Name = "txt_Buscar";
            txt_Buscar.Size = new Size(297, 25);
            txt_Buscar.TabIndex = 2;
            // 
            // btn_Buscar
            // 
            btn_Buscar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Buscar.Location = new Point(407, 37);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new Size(115, 34);
            btn_Buscar.TabIndex = 3;
            btn_Buscar.Text = "Buscar";
            btn_Buscar.UseVisualStyleBackColor = true;
            // 
            // lblSimbolo
            // 
            lblSimbolo.AutoSize = true;
            lblSimbolo.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSimbolo.Location = new Point(77, 246);
            lblSimbolo.Name = "lblSimbolo";
            lblSimbolo.Size = new Size(67, 21);
            lblSimbolo.TabIndex = 5;
            lblSimbolo.Text = "Simbolo";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPrecio.Location = new Point(77, 332);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(53, 21);
            lblPrecio.TabIndex = 6;
            lblPrecio.Text = "Precio";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(60, 450);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(740, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(60, 450);
            panel2.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(60, 412);
            panel3.Name = "panel3";
            panel3.Size = new Size(680, 38);
            panel3.TabIndex = 9;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(60, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(680, 38);
            panel4.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 106);
            label1.Name = "label1";
            label1.Size = new Size(153, 45);
            label1.TabIndex = 11;
            label1.Text = "Nombre ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(60, 201);
            label2.Name = "label2";
            label2.Size = new Size(154, 45);
            label2.TabIndex = 12;
            label2.Text = "Simbolo ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(60, 287);
            label3.Name = "label3";
            label3.Size = new Size(114, 45);
            label3.TabIndex = 13;
            label3.Text = "Precio";
            // 
            // frmBuscar
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblPrecio);
            Controls.Add(lblSimbolo);
            Controls.Add(btn_Buscar);
            Controls.Add(txt_Buscar);
            Controls.Add(lbl_Id);
            Controls.Add(pictureBox1);
            Name = "frmBuscar";
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
        private Label lblSimbolo;
        private Label lblPrecio;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
