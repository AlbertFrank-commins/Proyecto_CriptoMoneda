namespace Forns_Descripcion
{
    partial class frmGrafico
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            picLogo = new PictureBox();
            txtId = new TextBox();
            btn_Buscar = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            cbIntervalo = new ComboBox();
            lblNombre = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Location = new Point(446, 26);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(279, 251);
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // txtId
            // 
            txtId.Location = new Point(48, 74);
            txtId.Name = "txtId";
            txtId.Size = new Size(194, 25);
            txtId.TabIndex = 1;
            // 
            // btn_Buscar
            // 
            btn_Buscar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Buscar.Location = new Point(86, 167);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new Size(91, 38);
            btn_Buscar.TabIndex = 2;
            btn_Buscar.Text = "Buscar";
            btn_Buscar.UseVisualStyleBackColor = true;
            btn_Buscar.Click += btn_Buscar_Click_1;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(71, 295);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(629, 217);
            chart1.TabIndex = 3;
            chart1.Text = "chart1";
            // 
            // cbIntervalo
            // 
            cbIntervalo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIntervalo.FormattingEnabled = true;
            cbIntervalo.Location = new Point(49, 116);
            cbIntervalo.Name = "cbIntervalo";
            cbIntervalo.Size = new Size(193, 25);
            cbIntervalo.TabIndex = 4;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(287, 116);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 32);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(42, 538);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(734, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(42, 538);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(42, 518);
            panel3.Name = "panel3";
            panel3.Size = new Size(692, 20);
            panel3.TabIndex = 8;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(42, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(692, 20);
            panel4.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(692, 20);
            panel5.TabIndex = 9;
            // 
            // frmGrafico
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 538);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblNombre);
            Controls.Add(cbIntervalo);
            Controls.Add(chart1);
            Controls.Add(btn_Buscar);
            Controls.Add(txtId);
            Controls.Add(picLogo);
            Name = "frmGrafico";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picLogo;
        private TextBox txtId;
        private Button btn_Buscar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ComboBox cbIntervalo;
        private Label lblNombre;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}
