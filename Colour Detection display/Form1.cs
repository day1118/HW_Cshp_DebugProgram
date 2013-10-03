﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;


namespace Colour_Detection_display
{
    public partial class Form1 : Form
    {
        char stringDelimiter = ':';
        string currentPort = "";
        int plotLength = 50;

        IRModlue tpgIRFLTemp = new IRModlue("IRFL");

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

            
            tabControl1.TabPages.Add(tpgIRFLTemp);

            timer1.Enabled = true;
        }

        private void toolStripPort_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripItem;
            if(sender is ToolStripMenuItem)
            {
                toolStripItem = (ToolStripMenuItem)sender;
                deselectToolStripPort();
                toolStripItem.Checked = true;
                currentPort = toolStripItem.Text;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                displayPortStatus();

                if (serialPort.IsOpen)
                {
                    while (serialPort.BytesToRead > 0)
                    {
                        string text = serialPort.ReadLine();
                        addStringToOverviewList(text);
                        tpgIRFLTemp.addData(text);

                        string[] splitText = text.Split(stringDelimiter);

                        if (splitText.Length == 2)
                        {
                            String name = splitText[0];
                            String value = splitText[1];
                            int iValue = Convert.ToInt32(value);

                            switch (name)
                            {
                                case "IRFL_FRONT_Off":
                                    addDataToChart(iValue, chtIRFL_Front_Off);
                                    break;
                                case "IRFL_FRONT_On":
                                    addDataToChart(iValue, chtIRFL_Front_On);
                                    break;
                                case "IRFL_FRONT_Diff":
                                    addDataToChart(iValue, chtIRFL_Front_Diff);
                                    break;
                                case "IRFL_SIDE_Off":
                                    addDataToChart(iValue, chtIRFL_Side_Off);
                                    break;
                                case "IRFL_SIDE_On":
                                    addDataToChart(iValue, chtIRFL_Side_On);
                                    break;
                                case "IRFL_SIDE_Diff":
                                    addDataToChart(iValue, chtIRFL_Side_Diff);
                                    break;
                            }       
                        }
                    }
                }
                else
                {
                }
            }
            catch { }
        }

        private void deselectToolStripPort()
        {
            foreach (ToolStripMenuItem tempToolStripItem in toolStripPort.DropDownItems)
            {
                tempToolStripItem.Checked = false;
            }
        }

        private void toolStripConnect_Click(object sender, EventArgs e)
        {
            if(serialPort.IsOpen)
            {
                serialPort.Close();
            }
            else
            {
                if (currentPort != "")
                {
                    serialPort.PortName = currentPort;
                    serialPort.Open();
                }
            }
        }

        private void displayPortStatus()
        {
            string connectedStatus;
            if (serialPort.IsOpen)
            {
                connectedStatus = "Connected";
                toolStripConnect.Text = "Disconnect";
            }
            else
            {
                connectedStatus = "Not Connected";
                toolStripConnect.Text = "Connect";
            }
            
            if (currentPort != "")
                toolStripStatusPort.Text = currentPort + " - " + connectedStatus;
            else
                toolStripStatusPort.Text = connectedStatus;
        }

        private void addStringToOverviewList(string text)
        {
            string[] splitText = text.Split(stringDelimiter);

            if (splitText.Length == 2)
            {
                String name = splitText[0];
                String value = splitText[1];

                ListViewItem existingItem = null;

                for (int i = 0; i < lstOverview.Items.Count; i++)
                {
                    if (lstOverview.Items[i].Text.Equals(name))
                    {
                        existingItem = lstOverview.Items[i];
                        break;
                    }
                }

                if (existingItem == null)
                {
                    ListViewItem newItem = new ListViewItem(name);
                    newItem.SubItems.Add(value);
                    lstOverview.Items.Add(newItem);
                }
                else
                {
                    existingItem.SubItems[1].Text = value;
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
}
