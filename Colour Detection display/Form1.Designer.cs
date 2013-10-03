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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgOverview = new System.Windows.Forms.TabPage();
            this.lstOverview = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.statusStrip2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgOverview);
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
            this.tpgOverview.Controls.Add(this.lstOverview);
            this.tpgOverview.Location = new System.Drawing.Point(4, 22);
            this.tpgOverview.Name = "tpgOverview";
            this.tpgOverview.Size = new System.Drawing.Size(878, 848);
            this.tpgOverview.TabIndex = 2;
            this.tpgOverview.Text = "Overview";
            this.tpgOverview.UseVisualStyleBackColor = true;
            // 
            // lstOverview
            // 
            this.lstOverview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colValue});
            this.lstOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOverview.Location = new System.Drawing.Point(0, 0);
            this.lstOverview.Name = "lstOverview";
            this.lstOverview.Size = new System.Drawing.Size(878, 848);
            this.lstOverview.TabIndex = 0;
            this.lstOverview.UseCompatibleStateImageBehavior = false;
            this.lstOverview.View = System.Windows.Forms.View.Details;
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
            this.toolStripConnect.Click += new System.EventHandler(this.toolStripConnect_Click);
            // 
            // toolStripExit
            // 
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.Size = new System.Drawing.Size(119, 22);
            this.toolStripExit.Text = "Exit";
            this.toolStripExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
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
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPort;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.TabPage tpgOverview;
        private System.Windows.Forms.TabPage tpgMatL;
        private System.Windows.Forms.TabPage tpgMatR;
        private System.Windows.Forms.TabPage tpgBallColour;
        private System.Windows.Forms.TabPage tpgUltrasonics;
        private System.Windows.Forms.TabPage tpgCamera;
        private System.Windows.Forms.TabPage tpgCustom;
        private System.Windows.Forms.ToolStripMenuItem toolStripExit;
        private System.Windows.Forms.ListView lstOverview;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.ToolStripMenuItem toolStripPort;
        private System.Windows.Forms.ToolStripMenuItem toolStripConnect;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer timer1;

    }
}

