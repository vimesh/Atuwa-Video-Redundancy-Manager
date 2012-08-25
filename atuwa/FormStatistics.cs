using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace atuwa
{
    public partial class FormStatistics : Form
    {
        public FormStatistics(int match, int unmatch, string name)
        {
            InitializeComponent();
            labelStatistics.Text = name;
            int[] yValues = { match, unmatch };
            string[] xValues = { "Match", "Total" };
            chartStatistics.Series["Series1"].Points.DataBindXY(xValues, yValues);

            chartStatistics.Series["Series1"].Points[0].Color = Color.Blue;
            chartStatistics.Series["Series1"].Points[1].Color = Color.Red;
            chartStatistics.Series["Series1"].IsValueShownAsLabel = true;
            chartStatistics.Series["Series1"].ChartType = SeriesChartType.Pie;

            // chart1.Series["Series1"]["PieLabelStyle"] = "Disabled";

            chartStatistics.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            chartStatistics.Legends[0].Enabled = true;
        }
    }
}
