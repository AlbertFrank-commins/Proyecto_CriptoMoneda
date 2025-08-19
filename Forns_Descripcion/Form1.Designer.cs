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
            btnBuscar = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            cbIntervalo = new ComboBox();
            lblNombre = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Location = new Point(232, 69);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(278, 135);
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // txtId
            // 
            txtId.Location = new Point(125, 38);
            txtId.Name = "txtId";
            txtId.Size = new Size(156, 25);
            txtId.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(460, 40);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "button1";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(12, 225);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(776, 213);
            chart1.TabIndex = 3;
            chart1.Text = "chart1";
            // 
            // cbIntervalo
            // 
            cbIntervalo.FormattingEnabled = true;
            cbIntervalo.Location = new Point(287, 38);
            cbIntervalo.Name = "cbIntervalo";
            cbIntervalo.Size = new Size(156, 25);
            cbIntervalo.TabIndex = 4;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(125, 86);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(57, 17);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNombre);
            Controls.Add(cbIntervalo);
            Controls.Add(chart1);
            Controls.Add(btnBuscar);
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
        private Button btnBuscar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ComboBox cbIntervalo;
        private Label lblNombre;
    }
}
