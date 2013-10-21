using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Colour_Detection_display
{
    class CameraModule : TabPage
    {
        int bestWidth = 0;
        int bestStart = 0;
        char stringDelimiter = ':';

        TableLayoutPanel layoutPanel = new TableLayoutPanel();
        Chart[] charts = new CameraChart[2];
        int rows = 1;
        int cols = 2;

        public CameraModule(string name)
        {
            this.Name = "tpg" + name;
            this.Text = "Camera";

            charts[0] = new CameraChart(name + " Raw");
            charts[1] = new CameraChart(name + " Peak Detect");

            Series newSeries = new Series("Center");
            newSeries.Color = System.Drawing.Color.Red;
            charts[1].Series.Add(newSeries);

            layoutPanel.ColumnCount = cols;
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            layoutPanel.RowCount = rows;
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int chartPos = (cols * row) + col;
                    layoutPanel.Controls.Add(charts[chartPos], col, row);
                }
            }

            layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;

            this.Controls.Add(layoutPanel);
        }

        public void addData(string text)
        {
            string[] splitText = text.Split(stringDelimiter);
            String name = splitText[0];

            if (splitText.Length > 125 && splitText.Length < 135)
            {
                if (name.Equals("CAM_RAW"))
                {
                    while (charts[0].Series[0].Points.Count > 0)
                        charts[0].Series[0].Points.RemoveAt(0);

                    for (int i = 1; i < splitText.Length; i++)
                    {
                        String value = splitText[i];
                        int iValue = Convert.ToInt32(value);
                        charts[0].Series[0].Points.AddXY(i, iValue);
                    }

                    charts[0].ChartAreas[0].RecalculateAxesScale();
                }
            }
            else if (splitText.Length == 2)
            {
                String value = splitText[1];
                int iValue = Convert.ToInt32(value);

                if (name.Equals("CAM_Start"))
                {
                    bestStart = iValue;
                    updatePeakDetectPlot();
                }
                else if (name.Equals("CAM_Width"))
                {
                    bestWidth = iValue;
                    updatePeakDetectPlot();
                }
            }
        }

        void updatePeakDetectPlot()
        {
            Chart chart = charts[1];

            if (bestWidth > 0)
                chart.Series[1].Points.AddXY(bestStart + (bestWidth / 2), 1);

            while (chart.Series[0].Points.Count < 128)
            {
                chart.Series[0].Points.Add(0);
            }

            while (chart.Series[0].Points.Count > 128)
            {
                chart.Series[0].Points.RemoveAt(0);
            }

            for(int i = 0; i < chart.Series[0].Points.Count; i++)
            {
                if (i >= bestStart && i <= (bestStart + bestWidth) && bestWidth > 0 && (i != (bestStart + (bestWidth/2))))
                    chart.Series[0].Points[i].SetValueY(1);
                else
                    chart.Series[0].Points[i].SetValueY(0);
            }

            while (chart.Series[1].Points.Count > 0)
            {
                chart.Series[1].Points.RemoveAt(0);
            }

            chart.ChartAreas[0].RecalculateAxesScale();
        }

        public void setLockedAxis(bool lockAxis)
        {
            foreach (Chart chart in charts)
            {
                if (lockAxis)
                {
                    chart.ChartAreas[0].AxisY.Maximum = 1024;
                    chart.ChartAreas[0].AxisY.Minimum = 0;
                }
                else
                {
                    chart.ChartAreas[0].AxisY.Maximum = Double.NaN;
                    chart.ChartAreas[0].AxisY.Minimum = Double.NaN;
                }
            }
        }

        class CameraChart : Chart
        {
            public CameraChart(string name)
            {
                string simpleName = name.Replace(" ", "_");
                this.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ChartAreas.Add(new ChartArea("chartArea"));
                this.Titles.Add(name);
                this.Name = simpleName;
                this.Series.Add(simpleName);
            }
        }
    }
}
