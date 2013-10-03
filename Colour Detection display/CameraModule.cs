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
