using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Colour_Detection_display
{
    class IRModule : CustomTabPage
    {
        public IRModule(string name) : base(name, name)
        {
            string dir;
            if(name.Substring(2, 1).Equals("F"))
                dir = "Front";
            else
                dir = "Back";
            
            charts = new IRChart[6];

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
        }

        class IRChart : CustomChart
        {
            public IRChart(string name): base(name) {}
        }
    }
}
