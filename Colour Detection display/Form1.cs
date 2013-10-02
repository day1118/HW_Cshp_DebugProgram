using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Colour_Detection_display
{
    public partial class Form1 : Form
    {
        int curLed1 = 0;
        int curLed2 = 0;
        int curLed3 = 0;
        int WhiteLed1 = 0;
        int WhiteLed2 = 0;
        int WhiteLed3 = 0;
        int GreenLed1 = 0;
        int GreenLed2 = 0;
        int GreenLed3 = 0;
        int RedLed1 = 0;
        int RedLed2 = 0;
        int RedLed3 = 0;
        int YellowLed1 = 0;
        int YellowLed2 = 0;
        int YellowLed3 = 0;
        int BlueLed1 = 0;
        int BlueLed2 = 0;
        int BlueLed3 = 0;
        int BlackLed1 = 0;
        int BlackLed2 = 0;
        int BlackLed3 = 0;

        int plotTime = 200;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            timer1.Enabled = true;

            chtIR1.Series[0].Points.Clear();
            chtIR2.Series[0].Points.Clear();
            chtIR3.Series[0].Points.Clear();
            chtIR4.Series[0].Points.Clear();

            chtUltrasonics.Series[0].Points.Clear();

            chtBall.Series[0].Points.Clear();
            chtBall.Series[1].Points.Clear();

            chtGround.Series[0].Points.Clear();
            chtGround.Series[1].Points.Clear();

            /*chtIR1.ChartAreas[0].AxisY.Maximum = 1024;
            chtIR2.ChartAreas[0].AxisY.Maximum = 1024;
            chtIR3.ChartAreas[0].AxisY.Maximum = 1024;
            chtIR4.ChartAreas[0].AxisY.Maximum = 1024;*/

            chtCamera.Series[0].Points.Clear();

            for (int i = 0; i < 130; i++)
            {
                chtCamera.Series[0].Points.AddXY(i, 1200);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (serialPort1.BytesToRead > 0)
            {
                string text = serialPort1.ReadLine();
                if (text.StartsWith("led1"))
                    lblCurLed1.Text = text;
                if (text.StartsWith("led2"))
                    lblCurLed2.Text = text;
                if (text.StartsWith("led3"))
                    lblCurLed3.Text = text;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    btnEnableSerial.Text = "Disable";
                    while (serialPort1.BytesToRead > 0)
                    {
                        string text = serialPort1.ReadLine();
                        if (text.StartsWith("led1"))
                        {
                            lblCurLed1.Text = text;
                            curLed1 = Convert.ToInt32(text.Substring(6));
                        }
                        else if (text.StartsWith("led2"))
                        {
                            lblCurLed2.Text = text;
                            curLed2 = Convert.ToInt32(text.Substring(6));
                        }
                        else if (text.StartsWith("led3"))
                        {
                            lblCurLed3.Text = text;
                            curLed3 = Convert.ToInt32(text.Substring(6));
                        }
                        else if (text.StartsWith("colour?"))
                        {
                            int colourNumber = -1;
                            switch (lblColour.Text)
                            {
                                case "White":
                                    colourNumber = 0;
                                    break;
                                case "Green":
                                    colourNumber = 1;
                                    break;
                                case "Red":
                                    colourNumber = 2;
                                    break;
                                case "Yellow":
                                    colourNumber = 3;
                                    break;
                                case "Blue":
                                    colourNumber = 4;
                                    break;
                                case "Black":
                                    colourNumber = 5;
                                    break;
                            }
                            serialPort1.Write(colourNumber.ToString());
                        }
                        else if (text.StartsWith("colour="))
                        {
                            lblColourReported.Text = text;
                        }
                        else if (text.StartsWith("GR-"))
                        {
                            label1.Text = text;
                            while (chtGround.Series[0].Points.Count > plotTime)
                            {
                                chtGround.Series[0].Points.RemoveAt(0);
                            }
                            chtGround.Update();
                            chtGround.Series[0].Points.AddY(Convert.ToInt32(text.Substring(3)));
                        }
                        else if (text.StartsWith("GG-"))
                        {
                            label2.Text = text;
                            while (chtGround.Series[1].Points.Count > plotTime)
                            {
                                chtGround.Series[1].Points.RemoveAt(0);
                            }
                            chtGround.Update();
                            chtGround.Series[1].Points.AddY(Convert.ToInt32(text.Substring(3)));
                        }
                        else if (text.StartsWith("BR-"))
                        {
                            label3.Text = text;
                            while (chtBall.Series[0].Points.Count > plotTime)
                            {
                                chtBall.Series[0].Points.RemoveAt(0);
                            }
                            chtBall.Update();
                            chtBall.Series[0].Points.AddY(Convert.ToInt32(text.Substring(3)));
                        }
                        else if (text.StartsWith("BI-"))
                        {
                            label4.Text = text;
                            while (chtBall.Series[1].Points.Count > plotTime)
                            {
                                chtBall.Series[1].Points.RemoveAt(0);
                            }
                            chtBall.Update();
                            chtBall.Series[1].Points.AddY(Convert.ToInt32(text.Substring(3)));
                        }
                        else if (text.StartsWith("S-"))
                        {
                            label5.Text = text;
                        }
                        else if (text.StartsWith("U-"))
                        {
                            label10.Text = text;
                            while (chtUltrasonics.Series[0].Points.Count > plotTime)
                            {
                                chtUltrasonics.Series[0].Points.RemoveAt(0);
                            }
                            chtUltrasonics.Update();
                            chtUltrasonics.Series[0].Points.AddY(Convert.ToInt32(text.Substring(2)));
                        }
                        else if (text.StartsWith("IR1-"))
                        {
                            label6.Text = text;
                            while (chtIR1.Series[0].Points.Count > plotTime)
                            {
                                chtIR1.Series[0].Points.RemoveAt(0);
                            }
                            chtIR1.Update();
                            chtIR1.Series[0].Points.AddY(Convert.ToInt32(text.Substring(4)));
                        }
                        else if (text.StartsWith("IR2-"))
                        {
                            label7.Text = text;
                            while (chtIR2.Series[0].Points.Count > plotTime)
                            {
                                chtIR2.Series[0].Points.RemoveAt(0);
                            }
                            chtIR2.Update();
                            chtIR2.Series[0].Points.AddY(Convert.ToInt32(text.Substring(4)));
                        }
                        else if (text.StartsWith("IR3-"))
                        {
                            label8.Text = text;
                            while (chtIR3.Series[0].Points.Count > plotTime)
                            {
                                chtIR3.Series[0].Points.RemoveAt(0);
                            }
                            chtIR3.Update();
                            chtIR3.Series[0].Points.AddY(Convert.ToInt32(text.Substring(4)));
                        }
                        else if (text.StartsWith("IR4-"))
                        {
                            label9.Text = text;
                            while (chtIR4.Series[0].Points.Count > plotTime)
                            {
                                chtIR4.Series[0].Points.RemoveAt(0);
                            }
                            chtIR4.Update();
                            chtIR4.Series[0].Points.AddY(Convert.ToInt32(text.Substring(4)));
                        }
                        else if (text.StartsWith("C"))
                        {
                            //label9.Text = text;
                            String[] splitString2 = text.Substring(1).Split('-');
                            if (splitString2.Length == 2)
                            {
                                int number = 0;
                                int value = 0;

                                try
                                {
                                    number = Convert.ToInt32(splitString2[0]);
                                    value = Convert.ToInt32(splitString2[1]);
                                }
                                catch { }

                                chtCamera.Series[0].Points[number].YValues[0] = value;
                                chtCamera.Refresh();
                            }
                        }
                        else if (text.StartsWith("BD-"))
                        {
                            label11.Text = text;
                        }
                        else if (text.StartsWith("bestWidth-"))
                        {
                            label12.Text = text;
                        }
                        else if (text.StartsWith("bestStart-"))
                        {
                            label13.Text = text;
                        }
                        else if (text.StartsWith("LP-"))
                        {
                            label14.Text = text;
                        }
                        else
                        {
                            lblColourReported.Text = "? " + text;
                        }

                        // Determine if there is a - in the string
                        String[] splitString = text.Split('-');
                        if (splitString.Length == 2)
                        {
                            String name = splitString[0];
                            String value = splitString[1];

                            ListViewItem existingItem = null;

                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                if (listView1.Items[i].Text.Equals(name))
                                {
                                    existingItem = listView1.Items[i];
                                    break;
                                }
                            }

                            if (existingItem == null)
                            {
                                ListViewItem newItem = new ListViewItem(name);
                                newItem.SubItems.Add(value);
                                listView1.Items.Add(newItem);
                            }
                            else
                            {
                                existingItem.SubItems[1].Text = value;
                            }
                        }
                    }

                    double minSumSqrError = 10000000;
                    double tempSumSqrError = 0;
                    string bestColour = "Unknown";

                    tempSumSqrError = Math.Pow(curLed1 - WhiteLed1, 2) + Math.Pow(curLed2 - WhiteLed2, 2) + Math.Pow(curLed3 - WhiteLed3, 2);
                    lblWhiteSSE.Text = tempSumSqrError.ToString();
                    if (tempSumSqrError < minSumSqrError)
                    {
                        minSumSqrError = tempSumSqrError;
                        bestColour = "White";
                    }

                    tempSumSqrError = Math.Pow(curLed1 - GreenLed1, 2) + Math.Pow(curLed2 - GreenLed2, 2) + Math.Pow(curLed3 - GreenLed3, 2);
                    lblGreenSSE.Text = tempSumSqrError.ToString();
                    if (tempSumSqrError < minSumSqrError)
                    {
                        minSumSqrError = tempSumSqrError;
                        bestColour = "Green";
                    }

                    tempSumSqrError = Math.Pow(curLed1 - RedLed1, 2) + Math.Pow(curLed2 - RedLed2, 2) + Math.Pow(curLed3 - RedLed3, 2);
                    lblRedSSE.Text = tempSumSqrError.ToString();
                    if (tempSumSqrError < minSumSqrError)
                    {
                        minSumSqrError = tempSumSqrError;
                        bestColour = "Red";
                    }

                    tempSumSqrError = Math.Pow(curLed1 - YellowLed1, 2) + Math.Pow(curLed2 - YellowLed2, 2) + Math.Pow(curLed3 - YellowLed3, 2);
                    lblYellowSSE.Text = tempSumSqrError.ToString();
                    if (tempSumSqrError < minSumSqrError)
                    {
                        minSumSqrError = tempSumSqrError;
                        bestColour = "Yellow";
                    }

                    tempSumSqrError = Math.Pow(curLed1 - BlueLed1, 2) + Math.Pow(curLed2 - BlueLed2, 2) + Math.Pow(curLed3 - BlueLed3, 2);
                    lblBlueSSE.Text = tempSumSqrError.ToString();
                    if (tempSumSqrError < minSumSqrError)
                    {
                        minSumSqrError = tempSumSqrError;
                        bestColour = "Blue";
                    }

                    tempSumSqrError = Math.Pow(curLed1 - BlackLed1, 2) + Math.Pow(curLed2 - BlackLed2, 2) + Math.Pow(curLed3 - BlackLed3, 2);
                    lblBlackSSE.Text = tempSumSqrError.ToString();
                    if (tempSumSqrError < minSumSqrError)
                    {
                        minSumSqrError = tempSumSqrError;
                        bestColour = "Black";
                    }

                    lblColour.Text = bestColour;

                    lblWhiteLed1.Text = WhiteLed1.ToString();
                    lblWhiteLed2.Text = WhiteLed2.ToString();
                    lblWhiteLed3.Text = WhiteLed3.ToString();

                    lblGreenLed1.Text = GreenLed1.ToString();
                    lblGreenLed2.Text = GreenLed2.ToString();
                    lblGreenLed3.Text = GreenLed3.ToString();

                    lblRedLed1.Text = RedLed1.ToString();
                    lblRedLed2.Text = RedLed2.ToString();
                    lblRedLed3.Text = RedLed3.ToString();

                    lblYellowLed1.Text = YellowLed1.ToString();
                    lblYellowLed2.Text = YellowLed2.ToString();
                    lblYellowLed3.Text = YellowLed3.ToString();

                    lblBlueLed1.Text = BlueLed1.ToString();
                    lblBlueLed2.Text = BlueLed2.ToString();
                    lblBlueLed3.Text = BlueLed3.ToString();

                    lblBlackLed1.Text = BlackLed1.ToString();
                    lblBlackLed2.Text = BlackLed2.ToString();
                    lblBlackLed3.Text = BlackLed3.ToString();
                }
                else
                {
                    //serialPort1.Open();
                    btnEnableSerial.Text = "Enable";
                }
            }
            catch
            {}
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            WhiteLed1 = curLed1;
            WhiteLed2 = curLed2;
            WhiteLed3 = curLed3;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            GreenLed1 = curLed1;
            GreenLed2 = curLed2;
            GreenLed3 = curLed3;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            RedLed1 = curLed1;
            RedLed2 = curLed2;
            RedLed3 = curLed3;
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            YellowLed1 = curLed1;
            YellowLed2 = curLed2;
            YellowLed3 = curLed3;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            BlueLed1 = curLed1;
            BlueLed2 = curLed2;
            BlueLed3 = curLed3;
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            BlackLed1 = curLed1;
            BlackLed2 = curLed2;
            BlackLed3 = curLed3;
        }

        private void btnEnableSerial_Click(object sender, EventArgs e)
        {
            if (btnEnableSerial.Text == "Enable")
            {
                try
                {
                    serialPort1.Open();
                    btnEnableSerial.Text = "Disable";
                }
                catch
                {}
            }
            else if (btnEnableSerial.Text == "Disable")
            {
                serialPort1.Close();
                btnEnableSerial.Text = "Enable";
            }
        }
    }
}
