using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;


namespace Colour_Detection_display
{
    public partial class Form1 : Form
    {
        char stringDelimiter = ':';
        string currentPort = "";
        int plotLength = 50;

        bool lockAxis = false;

        bool waitingToConnect = false;

        SafeSerialPort serialPort;

        public static bool serialPortOpen = false;

        OverviewModule tpgOverview = new OverviewModule("Overview");
        IRModule tpgIRFL = new IRModule("IRFL");
        IRModule tpgIRFR = new IRModule("IRFR");
        IRModule tpgIRBL = new IRModule("IRBL");
        IRModule tpgIRBR = new IRModule("IRBR");
        ColourModule tpgGML = new ColourModule("GML");
        ColourModule tpgGMR = new ColourModule("GMR");
        ColourModule tpgBALL = new ColourModule("BALL");
        MotorsModule tpgMotors = new MotorsModule("MTR");
        ServoModule tpgServos = new ServoModule("Servo");
        EncoderModule tpgEncoderLeft = new EncoderModule("ENC_Left");
        EncoderModule tpgEncoderRight = new EncoderModule("ENC_Right");
        CameraModule tpgCamera = new CameraModule("Camera");
        UltrasonicsModule tpgUltrasonics = new UltrasonicsModule("US");
        MicroswitchModule tpgMicroswitchs = new MicroswitchModule("Micro");
        CustomModule tpgCustom = new CustomModule("Custom");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateSerialPortList();

            tabControl1.TabPages.Remove(tpgSettings);
            tabControl1.TabPages.Add(tpgOverview);
            tabControl1.TabPages.Add(tpgIRFL);
            tabControl1.TabPages.Add(tpgIRFR);
            tabControl1.TabPages.Add(tpgIRBL);
            tabControl1.TabPages.Add(tpgIRBR);
            tabControl1.TabPages.Add(tpgGML);
            tabControl1.TabPages.Add(tpgGMR);
            tabControl1.TabPages.Add(tpgBALL);
            tabControl1.TabPages.Add(tpgUltrasonics);
            tabControl1.TabPages.Add(tpgMotors);
            tabControl1.TabPages.Add(tpgServos);
            tabControl1.TabPages.Add(tpgEncoderLeft);
            tabControl1.TabPages.Add(tpgEncoderRight);
            tabControl1.TabPages.Add(tpgCamera);
            tabControl1.TabPages.Add(tpgMicroswitchs);
            tabControl1.TabPages.Add(tpgCustom);
            tabControl1.TabPages.Add(tpgSettings);

            tpgCustom.setup(tabControl1);

            if (toolStripPort.DropDownItems.Count > 0)
            {
                // Select the first port avaliable as a guess
                toolStripPort_Click(toolStripPort.DropDownItems[0], null);
                toolStripConnect_Click(toolStripConnect, null);
            }

            timer1.Enabled = true;
        }

        private void toolStripPort_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripItem;
            if (sender is ToolStripMenuItem)
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
                if (Form1.ActiveForm == null)
                {
                    // Disconnect because we don't have focus.
                    if (serialPort != null && serialPort.IsOpen)
                    {
                        toolStripConnect_Click(toolStripConnect, null);
                    }
                }
                
                if (serialPort != null && !serialPort.IsOpen)
                {
                    if (waitingToConnect)
                    {
                        toolStripConnect_Click(toolStripConnect, null);
                    }
                }

                updateSerialPortList();
                displayPortStatus();
                if (serialPort != null && serialPort.IsOpen)
                {
                    while (serialPort.BytesToRead > 0)
                    {
                        string text = serialPort.ReadLine();
                        if (text != "")
                        {
                              string[] splitText = text.Split(stringDelimiter);

                              if (splitText.Length == 2)
                              {
                                  String name = splitText[0];
                                  String value = splitText[1];
                                  int iValue;
                                  if (Int32.TryParse(value, out iValue))
                                  {
                                      tpgOverview.addData(text);
                                      tpgIRFL.addData(text);
                                      tpgIRFR.addData(text);
                                      tpgIRBL.addData(text);
                                      tpgIRBR.addData(text);
                                      tpgGML.addData(text);
                                      tpgGMR.addData(text);
                                      tpgBALL.addData(text);
                                      tpgUltrasonics.addData(text);
                                      tpgServos.addData(text);
                                      tpgEncoderLeft.addData(text);
                                      tpgEncoderRight.addData(text);
                                      tpgMotors.addData(text);
                                      tpgCamera.addData(text);
                                      tpgMicroswitchs.addData(text);
                                      tpgCustom.addData(text);
                                  }
                              }
                              else
                              {
                                  tpgCamera.addData(text);
                              }
                        }
                    }
                    serialPort.Write(" ");      // Used to test if we still have a connection
                }
                else
                {
                }
            }
            catch (IOException exception)
            {
                serialPort.Dispose();
            }
            catch (TimeoutException exception)
            {
                serialPort.Dispose();
            }
            catch (Exception exception)
            {
            }
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
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
            else
            {
                if (currentPort != "")
                {
                    serialPort = new SafeSerialPort(currentPort, 115200, Parity.None, 8, StopBits.One);
                    serialPort.ReadTimeout = 100;
                    serialPort.Open();
                    waitingToConnect = !serialPort.IsOpen;
                }
            }
        }

        private void displayPortStatus()
        {
            string connectedStatus;
            if (serialPort != null && serialPort.IsOpen)
            {
                connectedStatus = "Connected";
                toolStripConnect.Text = "Disconnect";
                serialPortOpen = true;
            }
            else
            {
                connectedStatus = "Not Connected";
                toolStripConnect.Text = "Connect";
                serialPortOpen = false;
            }

            if (currentPort != "")
                toolStripStatusPort.Text = currentPort + " - " + connectedStatus;
            else
                toolStripStatusPort.Text = connectedStatus;
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

        private void toolStripStatusPort_Click(object sender, EventArgs e)
        {
            toolStripConnect_Click(toolStripConnect, null);
        }

        private void lockAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox1_CheckedChanged(null, null);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            plotLength = (int)numericUpDown1.Value;
            tpgIRFL.setPlotLength(plotLength);
            tpgIRFR.setPlotLength(plotLength);
            tpgIRBL.setPlotLength(plotLength);
            tpgIRBR.setPlotLength(plotLength);
            tpgGML.setPlotLength(plotLength);
            tpgGMR.setPlotLength(plotLength);
            tpgBALL.setPlotLength(plotLength);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lockAxis = !lockAxis;

            lockAxisToolStripMenuItem.Checked = lockAxis;
            checkBox1.Checked = lockAxis;

            tpgIRFL.setLockedAxis(lockAxis);
            tpgIRFR.setLockedAxis(lockAxis);
            tpgIRBL.setLockedAxis(lockAxis);
            tpgIRBR.setLockedAxis(lockAxis);
            tpgGML.setLockedAxis(lockAxis);
            tpgGMR.setLockedAxis(lockAxis);
            tpgBALL.setLockedAxis(lockAxis);
        }

        private void updateSerialPortList()
        {
            foreach (ToolStripMenuItem menuItem in toolStripPort.DropDownItems)
                menuItem.Tag = false;   // Use tag to record if the port still exists

            String[] portNames = SerialPort.GetPortNames();
            foreach (string portName in portNames)
            {
                bool found = false;
                foreach (ToolStripMenuItem menuItem in toolStripPort.DropDownItems)
                {
                    if (menuItem.Text.Equals(portName))
                    {
                        found = true;
                        menuItem.Tag = true;
                    }
                }

                if (!found)
                {
                    addPortToList(portName);
                }
            }

            for (int i = 0; i < toolStripPort.DropDownItems.Count; i++)
            {
                ToolStripItem menuItem = toolStripPort.DropDownItems[i];
                if (!(bool)menuItem.Tag)
                {
                    toolStripPort.DropDownItems.Remove(menuItem);
                    if (menuItem.Text.Equals(currentPort))
                        currentPort = "";
                }
            }
        }

        private void addPortToList(String portName)
        {
            ToolStripMenuItem newToolStrip = new ToolStripMenuItem();
            newToolStrip.Name = "toolStrip" + portName;
            newToolStrip.Text = portName;
            newToolStrip.Tag = true;
            newToolStrip.Click += new System.EventHandler(this.toolStripPort_Click);
            toolStripPort.DropDownItems.Add(newToolStrip);

            if (currentPort.Equals(""))
                toolStripPort_Click(newToolStrip, null);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            // Try and connect because we got the focus back
            if (serialPort != null && !serialPort.IsOpen)
            {
                toolStripConnect_Click(toolStripConnect, null);
            }
        }

    }
}
