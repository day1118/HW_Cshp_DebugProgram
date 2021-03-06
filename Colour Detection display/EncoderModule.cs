﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Colour_Detection_display
{
    class EncoderModule : TabPage
    {
        TableLayoutPanel layoutPanel = new TableLayoutPanel();
        Chart[] charts = new EncoderChart[6];

        int rows = 2;
        int cols = 3;

        int plotLength = 50;
        char stringDelimiter = ':';

        public EncoderModule(string name)
        {
            this.Name = "tpg" + name;
            this.Text = name;

            charts[0] = new EncoderChart(name + " Off");
            charts[1] = new EncoderChart(name + " On");
            charts[2] = new EncoderChart(name + " Diff");
            charts[3] = new EncoderChart(name + " Motor Speed");
            charts[4] = new EncoderChart(name + " State");
            charts[5] = new EncoderChart(name + " Count");

            layoutPanel.ColumnCount = cols;
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / cols));
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / cols));
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / cols));
            layoutPanel.RowCount = rows;
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F / rows));
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F / rows));

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

        public void setPlotLength(int newLength)
        {
            plotLength = newLength;
        }

        public void addData(string text)
        {
            string[] splitText = text.Split(stringDelimiter);

            if (splitText.Length == 2)
            {
                String name = splitText[0];
                String value = splitText[1];
                int iValue = Convert.ToInt32(value);
                
                if(name.StartsWith(this.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    foreach (Chart chart in charts)
                    {
                        if (chart.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                            addDataToChart(iValue, chart);
                    }
                }
            }
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

        private void addDataToChart(int data, Chart chart)
        {
            while (chart.Series[0].Points.Count > plotLength)
            {
                chart.Series[0].Points.RemoveAt(0);
            }

            chart.Series[0].Points.AddY(data);
            chart.ChartAreas[0].RecalculateAxesScale();
        }

        class EncoderChart : Chart
        {
            public EncoderChart(string name)
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
