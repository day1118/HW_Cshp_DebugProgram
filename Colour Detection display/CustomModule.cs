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

        AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();

        public CustomModule(string name) : base(name, name)
        {
            this.Name = "tpg" + name;
            this.Text = name;

            charts = new CustomTabChart[6];

            for (int i = 0; i < 6; i++)
            {
                charts[i] = new CustomTabChart(name + " " + (i+1));
                charts[i].TabStop = false;
                textboxs[i] = new CustomTextbox(name + " " + (i+1));
                textboxs[i].AutoCompleteMode = AutoCompleteMode.Suggest;
                textboxs[i].AutoCompleteSource = AutoCompleteSource.CustomSource;
                textboxs[i].AutoCompleteCustomSource = autoCompleteData;
            }

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

        public new void addData(string text)
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

                if(!autoCompleteData.Contains(name))
                {
                    autoCompleteData.Add(name);
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
