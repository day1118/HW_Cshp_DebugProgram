using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Colour_Detection_display
{
    class IRModule : TabPage
    {
        TableLayoutPanel layoutPanel = new TableLayoutPanel();
        Chart[] charts = new IRChart[6];
        int plotLength = 50;
        char stringDelimiter = ':';

        public IRModule(string name)
        {
            this.Name = "tpg" + name;
            this.Text = name;

            string dir;
            if(name.Substring(2, 1).Equals("F"))
                dir = "Front";
            else
                dir = "Back";

            charts[0] = new IRChart(name + " " + dir + " Off");
            charts[1] = new IRChart(name + " " + dir + " On");
            charts[2] = new IRChart(name + " " + dir + " Diff");
            charts[3] = new IRChart(name + " Side Off");
            charts[4] = new IRChart(name + " Side On");
            charts[5] = new IRChart(name + " Side Diff");

            layoutPanel.ColumnCount = 3;
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            layoutPanel.RowCount = 2;
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

            for (int row = 0; row < layoutPanel.RowCount; row++)
            {
                for (int col = 0; col < layoutPanel.ColumnCount; col++)
                {
                    int chartPos = (3 * row) + col;
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
                
                if(name.StartsWith(this.Text))
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

        class IRChart : Chart
        {
            public IRChart(string name)
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
