namespace Forns_Descripcion
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            picLogo = new PictureBox();
            txtId = new TextBox();
            btn_Buscar = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            cbIntervalo = new ComboBox();
            lblNombre = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Location = new Point(308, 78);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(317, 251);
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // txtId
            // 
            txtId.Location = new Point(134, 36);
            txtId.Name = "txtId";
            txtId.Size = new Size(201, 25);
            txtId.TabIndex = 1;
            // 
            // btn_Buscar
            // 
            btn_Buscar.Location = new Point(643, 36);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new Size(75, 23);
            btn_Buscar.TabIndex = 2;
            btn_Buscar.Text = "button1";
            btn_Buscar.UseVisualStyleBackColor = true;
            btn_Buscar.Click += btn_Buscar_Click_1;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(50, 335);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(816, 245);
            chart1.TabIndex = 3;
            chart1.Text = "chart1";
            // 
            // cbIntervalo
            // 
            cbIntervalo.FormattingEnabled = true;
            cbIntervalo.Location = new Point(358, 36);
            cbIntervalo.Name = "cbIntervalo";
            cbIntervalo.Size = new Size(200, 25);
            cbIntervalo.TabIndex = 4;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(145, 169);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(57, 17);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 592);
            Controls.Add(lblNombre);
            Controls.Add(cbIntervalo);
            Controls.Add(chart1);
            Controls.Add(btn_Buscar);
            Controls.Add(txtId);
            Controls.Add(picLogo);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
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
    }
}
