namespace Colour_Detection_display
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend16 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea17 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend17 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea18 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend18 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgOverview = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpgIRFL = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart5 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart6 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tpgIRFR = new System.Windows.Forms.TabPage();
            this.tpgIRBL = new System.Windows.Forms.TabPage();
            this.tpgIRBR = new System.Windows.Forms.TabPage();
            this.tpgMatL = new System.Windows.Forms.TabPage();
            this.tpgMatR = new System.Windows.Forms.TabPage();
            this.tpgBallColour = new System.Windows.Forms.TabPage();
            this.tpgUltrasonics = new System.Windows.Forms.TabPage();
            this.tpgCamera = new System.Windows.Forms.TabPage();
            this.tpgCustom = new System.Windows.Forms.TabPage();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPort = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tpgOverview.SuspendLayout();
            this.tpgIRFL.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart6)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgOverview);
            this.tabControl1.Controls.Add(this.tpgIRFL);
            this.tabControl1.Controls.Add(this.tpgIRFR);
            this.tabControl1.Controls.Add(this.tpgIRBL);
            this.tabControl1.Controls.Add(this.tpgIRBR);
            this.tabControl1.Controls.Add(this.tpgMatL);
            this.tabControl1.Controls.Add(this.tpgMatR);
            this.tabControl1.Controls.Add(this.tpgBallColour);
            this.tabControl1.Controls.Add(this.tpgUltrasonics);
            this.tabControl1.Controls.Add(this.tpgCamera);
            this.tabControl1.Controls.Add(this.tpgCustom);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(886, 874);
            this.tabControl1.TabIndex = 1;
            // 
            // tpgOverview
            // 
            this.tpgOverview.Controls.Add(this.listView1);
            this.tpgOverview.Location = new System.Drawing.Point(4, 22);
            this.tpgOverview.Name = "tpgOverview";
            this.tpgOverview.Size = new System.Drawing.Size(878, 848);
            this.tpgOverview.TabIndex = 2;
            this.tpgOverview.Text = "Overview";
            this.tpgOverview.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colValue});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(878, 848);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 134;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            // 
            // tpgIRFL
            // 
            this.tpgIRFL.Controls.Add(this.tableLayoutPanel2);
            this.tpgIRFL.Location = new System.Drawing.Point(4, 22);
            this.tpgIRFL.Name = "tpgIRFL";
            this.tpgIRFL.Padding = new System.Windows.Forms.Padding(3);
            this.tpgIRFL.Size = new System.Drawing.Size(878, 848);
            this.tpgIRFL.TabIndex = 0;
            this.tpgIRFL.Text = "IRFL";
            this.tpgIRFL.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chart2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chart3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.chart4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chart5, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.chart6, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(872, 842);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea13.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea13);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend13.Name = "Legend1";
            this.chart1.Legends.Add(legend13);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series13.ChartArea = "ChartArea1";
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            this.chart1.Series.Add(series13);
            this.chart1.Size = new System.Drawing.Size(284, 415);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea14.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea14);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend14.Name = "Legend1";
            this.chart2.Legends.Add(legend14);
            this.chart2.Location = new System.Drawing.Point(293, 3);
            this.chart2.Name = "chart2";
            series14.ChartArea = "ChartArea1";
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            this.chart2.Series.Add(series14);
            this.chart2.Size = new System.Drawing.Size(284, 415);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea15.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea15);
            this.chart3.Dock = System.Windows.Forms.DockStyle.Fill;
            legend15.Name = "Legend1";
            this.chart3.Legends.Add(legend15);
            this.chart3.Location = new System.Drawing.Point(583, 3);
            this.chart3.Name = "chart3";
            series15.ChartArea = "ChartArea1";
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            this.chart3.Series.Add(series15);
            this.chart3.Size = new System.Drawing.Size(286, 415);
            this.chart3.TabIndex = 2;
            this.chart3.Text = "chart3";
            // 
            // chart4
            // 
            chartArea16.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea16);
            this.chart4.Dock = System.Windows.Forms.DockStyle.Fill;
            legend16.Name = "Legend1";
            this.chart4.Legends.Add(legend16);
            this.chart4.Location = new System.Drawing.Point(3, 424);
            this.chart4.Name = "chart4";
            series16.ChartArea = "ChartArea1";
            series16.Legend = "Legend1";
            series16.Name = "Series1";
            this.chart4.Series.Add(series16);
            this.chart4.Size = new System.Drawing.Size(284, 415);
            this.chart4.TabIndex = 3;
            this.chart4.Text = "chart4";
            // 
            // chart5
            // 
            chartArea17.Name = "ChartArea1";
            this.chart5.ChartAreas.Add(chartArea17);
            this.chart5.Dock = System.Windows.Forms.DockStyle.Fill;
            legend17.Name = "Legend1";
            this.chart5.Legends.Add(legend17);
            this.chart5.Location = new System.Drawing.Point(293, 424);
            this.chart5.Name = "chart5";
            series17.ChartArea = "ChartArea1";
            series17.Legend = "Legend1";
            series17.Name = "Series1";
            this.chart5.Series.Add(series17);
            this.chart5.Size = new System.Drawing.Size(284, 415);
            this.chart5.TabIndex = 4;
            this.chart5.Text = "chart5";
            // 
            // chart6
            // 
            chartArea18.Name = "ChartArea1";
            this.chart6.ChartAreas.Add(chartArea18);
            this.chart6.Dock = System.Windows.Forms.DockStyle.Fill;
            legend18.Name = "Legend1";
            this.chart6.Legends.Add(legend18);
            this.chart6.Location = new System.Drawing.Point(583, 424);
            this.chart6.Name = "chart6";
            series18.ChartArea = "ChartArea1";
            series18.Legend = "Legend1";
            series18.Name = "Series1";
            this.chart6.Series.Add(series18);
            this.chart6.Size = new System.Drawing.Size(286, 415);
            this.chart6.TabIndex = 5;
            this.chart6.Text = "chart6";
            // 
            // tpgIRFR
            // 
            this.tpgIRFR.Location = new System.Drawing.Point(4, 22);
            this.tpgIRFR.Name = "tpgIRFR";
            this.tpgIRFR.Padding = new System.Windows.Forms.Padding(3);
            this.tpgIRFR.Size = new System.Drawing.Size(878, 848);
            this.tpgIRFR.TabIndex = 1;
            this.tpgIRFR.Text = "IRFR";
            this.tpgIRFR.UseVisualStyleBackColor = true;
            // 
            // tpgIRBL
            // 
            this.tpgIRBL.Location = new System.Drawing.Point(4, 22);
            this.tpgIRBL.Name = "tpgIRBL";
            this.tpgIRBL.Size = new System.Drawing.Size(878, 848);
            this.tpgIRBL.TabIndex = 3;
            this.tpgIRBL.Text = "IRBL";
            this.tpgIRBL.UseVisualStyleBackColor = true;
            // 
            // tpgIRBR
            // 
            this.tpgIRBR.Location = new System.Drawing.Point(4, 22);
            this.tpgIRBR.Name = "tpgIRBR";
            this.tpgIRBR.Size = new System.Drawing.Size(878, 848);
            this.tpgIRBR.TabIndex = 4;
            this.tpgIRBR.Text = "IRBR";
            this.tpgIRBR.UseVisualStyleBackColor = true;
            // 
            // tpgMatL
            // 
            this.tpgMatL.Location = new System.Drawing.Point(4, 22);
            this.tpgMatL.Name = "tpgMatL";
            this.tpgMatL.Size = new System.Drawing.Size(878, 848);
            this.tpgMatL.TabIndex = 5;
            this.tpgMatL.Text = "MatL";
            this.tpgMatL.UseVisualStyleBackColor = true;
            // 
            // tpgMatR
            // 
            this.tpgMatR.Location = new System.Drawing.Point(4, 22);
            this.tpgMatR.Name = "tpgMatR";
            this.tpgMatR.Size = new System.Drawing.Size(878, 848);
            this.tpgMatR.TabIndex = 6;
            this.tpgMatR.Text = "MatR";
            this.tpgMatR.UseVisualStyleBackColor = true;
            // 
            // tpgBallColour
            // 
            this.tpgBallColour.Location = new System.Drawing.Point(4, 22);
            this.tpgBallColour.Name = "tpgBallColour";
            this.tpgBallColour.Size = new System.Drawing.Size(878, 848);
            this.tpgBallColour.TabIndex = 7;
            this.tpgBallColour.Text = "Ball Colour";
            this.tpgBallColour.UseVisualStyleBackColor = true;
            // 
            // tpgUltrasonics
            // 
            this.tpgUltrasonics.Location = new System.Drawing.Point(4, 22);
            this.tpgUltrasonics.Name = "tpgUltrasonics";
            this.tpgUltrasonics.Size = new System.Drawing.Size(878, 848);
            this.tpgUltrasonics.TabIndex = 8;
            this.tpgUltrasonics.Text = "Ultrasonics";
            this.tpgUltrasonics.UseVisualStyleBackColor = true;
            // 
            // tpgCamera
            // 
            this.tpgCamera.Location = new System.Drawing.Point(4, 22);
            this.tpgCamera.Name = "tpgCamera";
            this.tpgCamera.Size = new System.Drawing.Size(878, 848);
            this.tpgCamera.TabIndex = 9;
            this.tpgCamera.Text = "Camera";
            this.tpgCamera.UseVisualStyleBackColor = true;
            // 
            // tpgCustom
            // 
            this.tpgCustom.Location = new System.Drawing.Point(4, 22);
            this.tpgCustom.Name = "tpgCustom";
            this.tpgCustom.Size = new System.Drawing.Size(878, 848);
            this.tpgCustom.TabIndex = 10;
            this.tpgCustom.Text = "Custom";
            this.tpgCustom.UseVisualStyleBackColor = true;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusPort});
            this.statusStrip2.Location = new System.Drawing.Point(0, 898);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(886, 22);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "Stest";
            // 
            // toolStripStatusPort
            // 
            this.toolStripStatusPort.Name = "toolStripStatusPort";
            this.toolStripStatusPort.Size = new System.Drawing.Size(88, 17);
            this.toolStripStatusPort.Text = "Not Connected";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(886, 24);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripPort,
            this.toolStripConnect,
            this.toolStripExit});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // toolStripPort
            // 
            this.toolStripPort.Name = "toolStripPort";
            this.toolStripPort.Size = new System.Drawing.Size(119, 22);
            this.toolStripPort.Text = "Port";
            // 
            // toolStripConnect
            // 
            this.toolStripConnect.Name = "toolStripConnect";
            this.toolStripConnect.Size = new System.Drawing.Size(119, 22);
            this.toolStripConnect.Text = "Connect";
            // 
            // toolStripExit
            // 
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.Size = new System.Drawing.Size(119, 22);
            this.toolStripExit.Text = "Exit";
            this.toolStripExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(886, 920);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpgOverview.ResumeLayout(false);
            this.tpgIRFL.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart6)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgIRFL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tpgIRFR;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPort;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.TabPage tpgOverview;
        private System.Windows.Forms.TabPage tpgIRBL;
        private System.Windows.Forms.TabPage tpgIRBR;
        private System.Windows.Forms.TabPage tpgMatL;
        private System.Windows.Forms.TabPage tpgMatR;
        private System.Windows.Forms.TabPage tpgBallColour;
        private System.Windows.Forms.TabPage tpgUltrasonics;
        private System.Windows.Forms.TabPage tpgCamera;
        private System.Windows.Forms.TabPage tpgCustom;
        private System.Windows.Forms.ToolStripMenuItem toolStripExit;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart6;
        private System.Windows.Forms.ToolStripMenuItem toolStripPort;
        private System.Windows.Forms.ToolStripMenuItem toolStripConnect;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer timer1;

    }
}

