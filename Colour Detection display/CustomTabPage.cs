using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Colour_Detection_display
{
    abstract class CustomTabPage : TabPage
    {
        protected TableLayoutPanel layoutPanel = new TableLayoutPanel();
        protected CustomChart[] charts;
        protected int plotLength = 50;
        char stringDelimiter = ':';

        public CustomTabPage(string name, string text)
        {
            this.Name = "tpg" + name;
            this.Text = name;
        
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
    }

    class CustomChart : Chart
    {
        public CustomChart(string name)
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
