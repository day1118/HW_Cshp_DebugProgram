﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Colour_Detection_display
{
    class ServoModule : TabPage
    {
        TableLayoutPanel layoutPanel = new TableLayoutPanel();
        Chart[] charts = new ServoChart[4];

        int rows = 2;
        int cols = 2;

        int plotLength = 50;
        char stringDelimiter = ':';

        public ServoModule(string name)
        {
            this.Name = "tpg" + name;
            this.Text = name;

            charts[0] = new ServoChart(name + "FPos");
            charts[1] = new ServoChart(name + "BPos");
            charts[2] = new ServoChart(name + "State");
            charts[3] = new ServoChart(name + "KPos");

            layoutPanel.ColumnCount = cols;
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            layoutPanel.RowCount = rows;
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

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

        class ServoChart : Chart
        {
            public ServoChart(string name)
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
