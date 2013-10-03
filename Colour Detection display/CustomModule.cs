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
      
        public CustomModule(string name)
        {
            this.Name = "tpg" + name;
            this.Text = name;
        }

        public void addData(string text)
        {
        }
    }
}
