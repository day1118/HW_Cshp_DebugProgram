using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Colour_Detection_display
{
    class MotorsModule : TabPage
    {
        TableLayoutPanel layoutPanel = new TableLayoutPanel();
        Chart[] charts = new MotorChart[6];

        public MotorsModule(string name)
        {
            this.Name = "tpg" + name;
            this.Text = "Motors";

            charts[0] = new MotorChart(name + " SPEED Left");
            charts[1] = new MotorChart(name + " ENCODER Left");
            charts[2] = new MotorChart(name + " ENCODER COUNT Left");
            charts[3] = new MotorChart(name + " SPEED Right");
            charts[4] = new MotorChart(name + " ENCODER Right");
            charts[5] = new MotorChart(name + " ENCODER COUNT Right");

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

        public void addData(string text)
        {
        }

        class MotorChart : Chart
        {
            public MotorChart(string name)
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
