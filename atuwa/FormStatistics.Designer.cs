namespace atuwa
{
    partial class FormStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatistics));
            this.chartStatistics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelStatistics = new System.Windows.Forms.Label();
            this.labelVideoName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // chartStatistics
            // 
            this.chartStatistics.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chartStatistics.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.SystemColors.Control;
            legend1.Name = "Legend1";
            this.chartStatistics.Legends.Add(legend1);
            this.chartStatistics.Location = new System.Drawing.Point(0, 32);
            this.chartStatistics.Name = "chartStatistics";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartStatistics.Series.Add(series1);
            this.chartStatistics.Size = new System.Drawing.Size(381, 257);
            this.chartStatistics.TabIndex = 0;
            this.chartStatistics.Text = "chart1";
            // 
            // labelStatistics
            // 
            this.labelStatistics.AutoSize = true;
            this.labelStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatistics.Location = new System.Drawing.Point(209, 8);
            this.labelStatistics.Name = "labelStatistics";
            this.labelStatistics.Size = new System.Drawing.Size(51, 16);
            this.labelStatistics.TabIndex = 1;
            this.labelStatistics.Text = "label1";
            // 
            // labelVideoName
            // 
            this.labelVideoName.AutoSize = true;
            this.labelVideoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVideoName.Location = new System.Drawing.Point(116, 8);
            this.labelVideoName.Name = "labelVideoName";
            this.labelVideoName.Size = new System.Drawing.Size(98, 16);
            this.labelVideoName.TabIndex = 2;
            this.labelVideoName.Text = "Video Name:";
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(381, 288);
            this.Controls.Add(this.labelVideoName);
            this.Controls.Add(this.labelStatistics);
            this.Controls.Add(this.chartStatistics);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStatistics";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStatistics";
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistics;
        private System.Windows.Forms.Label labelStatistics;
        private System.Windows.Forms.Label labelVideoName;
    }
}