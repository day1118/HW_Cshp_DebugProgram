using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Colour_Detection_display
{
    class CustomModule : CustomTabPage
    {
        TextBox[] textboxs = new CustomTextbox[6];
        TabControl tabControl;

        public CustomModule(string name) : base(name, name)
        {
            this.Name = "tpg" + name;
            this.Text = name;

            charts = new CustomTabChart[6];

            charts[0] = new CustomTabChart(name + " 1");
            charts[1] = new CustomTabChart(name + " 2");
            charts[2] = new CustomTabChart(name + " 3");
            charts[3] = new CustomTabChart(name + " 4");
            charts[4] = new CustomTabChart(name + " 5");
            charts[5] = new CustomTabChart(name + " 6");

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
            string[] splitText = text.Split(stringDelimiter);

            if (splitText.Length == 2)
            {
                String name = splitText[0];
                String value = splitText[1];
                int iValue = Convert.ToInt32(value);

                foreach (Chart chart in charts)
                {
                    if (chart.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                        addDataToChart(iValue, chart);
                }
            }
        }

        public void setup(TabControl newTabControl)
        {
            tabControl = newTabControl;
            CustomTextbox.setup(null);
        }

        public void setChart(TextBox textBox)
        {
            CustomChart chart = charts[Array.IndexOf(textboxs, textBox)];
            String name = textBox.Text;
            chart.setTitle(name.Replace('_', ' '));            
            chart.Name = name.Replace(' ', '_');
            chart.clear();
        }
    }

    class CustomTabChart : CustomChart
    {
        public CustomTabChart(string name): base(name) {}
    }

    class CustomTextbox: TextBox
    {
        static CustomTabPage[] tabPages;

        public CustomTextbox(string name)
        {
            string simpleName = name.Replace(" ", "_");
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = simpleName;
            this.Text = name;
            this.TextAlign = HorizontalAlignment.Center;
            this.TextChanged += new System.EventHandler(this.textbox_TextChanged);
        }

        public static void setup(CustomTabPage[] newTabPages)
        {
            tabPages = newTabPages;
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox;
            String name;
            if (sender is TextBox)
            {
                textbox = (TextBox)sender;
                name = textbox.Text;

                CustomModule customModule = (CustomModule) this.Parent.Parent;
                customModule.setChart(textbox);
            }
        }
    }
}
