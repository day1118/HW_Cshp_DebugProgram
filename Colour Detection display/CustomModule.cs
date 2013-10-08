using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Colour_Detection_display
{
    class CustomModule : TabPage
    {
        TableLayoutPanel layoutPanel = new TableLayoutPanel();
        Chart[] charts = new CustomChart[6];
        TextBox[] textboxs = new CustomTextbox[6];
        int plotLength = 50;
        char stringDelimiter = ':';
      
        public CustomModule(string name)
        {
            this.Name = "tpg" + name;
            this.Text = name;

            charts[0] = new CustomChart(name + " 1");
            charts[1] = new CustomChart(name + " 2");
            charts[2] = new CustomChart(name + " 3");
            charts[3] = new CustomChart(name + " 4");
            charts[4] = new CustomChart(name + " 5");
            charts[5] = new CustomChart(name + " 6");

            textboxs[0] = new CustomTextbox(name + " 1");
            textboxs[1] = new CustomTextbox(name + " 2");
            textboxs[2] = new CustomTextbox(name + " 3");
            textboxs[3] = new CustomTextbox(name + " 4");
            textboxs[4] = new CustomTextbox(name + " 5");
            textboxs[5] = new CustomTextbox(name + " 6");

            layoutPanel.ColumnCount = 3;
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            layoutPanel.RowCount = 4;
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

            for (int row = 0; row < layoutPanel.RowCount/2; row++)
            {
                for (int col = 0; col < layoutPanel.ColumnCount; col++)
                {
                    int chartPos = (3 * row) + col;
                    layoutPanel.Controls.Add(charts[chartPos], col, (2*row)+1);
                    layoutPanel.Controls.Add(textboxs[chartPos], col, (2 * row));
                }
            }

            layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;

            this.Controls.Add(layoutPanel);
        }

        public void addData(string text)
        {
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

    class CustomTextbox: TextBox
    {
        public CustomTextbox(string name)
        {
            string simpleName = name.Replace(" ", "_");
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = simpleName;
            this.Text = name;
            this.TextAlign = HorizontalAlignment.Center;
            this.TextChanged += new System.EventHandler(this.textbox_TextChanged);
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            object a = this;//.parent.parent;

        }
    }
}
