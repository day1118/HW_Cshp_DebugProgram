using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;


namespace Colour_Detection_display
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string portName in SerialPort.GetPortNames())
            {
                ToolStripMenuItem newToolStrip = new ToolStripMenuItem();
                newToolStrip.Name = "toolStrip" + portName;
                newToolStrip.Text = portName;
                newToolStrip.Click += new System.EventHandler(this.toolStripPort_Click);
                toolStripPort.DropDownItems.Add(newToolStrip);
            }  
        }

        private void toolStripPort_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripItem;
            if(sender is ToolStripMenuItem)
            {
                toolStripItem = (ToolStripMenuItem)sender;
                toolStripStatusPort.Text = toolStripItem.Text;

                foreach(ToolStripMenuItem tempToolStripItem in toolStripPort.DropDownItems)
                {
                    tempToolStripItem.Checked = false;
                }
                toolStripItem.Checked = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
