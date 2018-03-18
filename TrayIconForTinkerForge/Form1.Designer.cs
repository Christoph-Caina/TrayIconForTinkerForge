namespace TrayIconForTinkerForge
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TFTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TFTryIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BrickDaemon = new System.Windows.Forms.ToolStripMenuItem();
            this.startServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programmBeendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_ServiceRestart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_ServiceStart = new System.Windows.Forms.Button();
            this.button_ServiceStop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sc = new System.ServiceProcess.ServiceController();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TFTryIconMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TFTrayIcon
            // 
            this.TFTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TFTrayIcon.ContextMenuStrip = this.TFTryIconMenu;
            this.TFTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TFTrayIcon.Icon")));
            this.TFTrayIcon.Text = "TinkerForge: BrickDaemonManager";
            this.TFTrayIcon.Visible = true;
            this.TFTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TFTrayIcon_MouseDoubleClick);
            // 
            // TFTryIconMenu
            // 
            this.TFTryIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BrickDaemon,
            this.logViewerToolStripMenuItem,
            this.programmBeendenToolStripMenuItem});
            this.TFTryIconMenu.Name = "TFTryIconMenu";
            this.TFTryIconMenu.Size = new System.Drawing.Size(181, 70);
            // 
            // BrickDaemon
            // 
            this.BrickDaemon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startServiceToolStripMenuItem,
            this.stopServiceToolStripMenuItem});
            this.BrickDaemon.Image = ((System.Drawing.Image)(resources.GetObject("BrickDaemon.Image")));
            this.BrickDaemon.Name = "BrickDaemon";
            this.BrickDaemon.Size = new System.Drawing.Size(180, 22);
            this.BrickDaemon.Text = "BrickDaemon";
            // 
            // startServiceToolStripMenuItem
            // 
            this.startServiceToolStripMenuItem.Enabled = false;
            this.startServiceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startServiceToolStripMenuItem.Image")));
            this.startServiceToolStripMenuItem.Name = "startServiceToolStripMenuItem";
            this.startServiceToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.startServiceToolStripMenuItem.Text = "StartService";
            this.startServiceToolStripMenuItem.Click += new System.EventHandler(this.StartServiceToolStripMenuItem_Click);
            // 
            // stopServiceToolStripMenuItem
            // 
            this.stopServiceToolStripMenuItem.Enabled = false;
            this.stopServiceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopServiceToolStripMenuItem.Image")));
            this.stopServiceToolStripMenuItem.Name = "stopServiceToolStripMenuItem";
            this.stopServiceToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.stopServiceToolStripMenuItem.Text = "StopService";
            this.stopServiceToolStripMenuItem.Click += new System.EventHandler(this.StopServiceToolStripMenuItem_Click);
            // 
            // logViewerToolStripMenuItem
            // 
            this.logViewerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logViewerToolStripMenuItem.Image")));
            this.logViewerToolStripMenuItem.Name = "logViewerToolStripMenuItem";
            this.logViewerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logViewerToolStripMenuItem.Text = "LogViewer";
            this.logViewerToolStripMenuItem.Click += new System.EventHandler(this.LogViewerToolStripMenuItem_Click);
            // 
            // programmBeendenToolStripMenuItem
            // 
            this.programmBeendenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("programmBeendenToolStripMenuItem.Image")));
            this.programmBeendenToolStripMenuItem.Name = "programmBeendenToolStripMenuItem";
            this.programmBeendenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.programmBeendenToolStripMenuItem.Text = "Programm Beenden";
            this.programmBeendenToolStripMenuItem.Click += new System.EventHandler(this.ProgrammBeendenToolStripMenuItem_Click);
            // 
            // button_ServiceRestart
            // 
            this.button_ServiceRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ServiceRestart.Image = ((System.Drawing.Image)(resources.GetObject("button_ServiceRestart.Image")));
            this.button_ServiceRestart.Location = new System.Drawing.Point(99, 36);
            this.button_ServiceRestart.Name = "button_ServiceRestart";
            this.button_ServiceRestart.Size = new System.Drawing.Size(40, 40);
            this.button_ServiceRestart.TabIndex = 10;
            this.button_ServiceRestart.UseVisualStyleBackColor = true;
            this.button_ServiceRestart.Click += new System.EventHandler(this.Button_ServiceRestart_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(311, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 9;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button_ServiceStart
            // 
            this.button_ServiceStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ServiceStart.Image = ((System.Drawing.Image)(resources.GetObject("button_ServiceStart.Image")));
            this.button_ServiceStart.Location = new System.Drawing.Point(7, 36);
            this.button_ServiceStart.Name = "button_ServiceStart";
            this.button_ServiceStart.Size = new System.Drawing.Size(40, 40);
            this.button_ServiceStart.TabIndex = 5;
            this.button_ServiceStart.UseVisualStyleBackColor = true;
            this.button_ServiceStart.Click += new System.EventHandler(this.Button_ServiceStart_Click);
            // 
            // button_ServiceStop
            // 
            this.button_ServiceStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ServiceStop.Image = ((System.Drawing.Image)(resources.GetObject("button_ServiceStop.Image")));
            this.button_ServiceStop.Location = new System.Drawing.Point(53, 36);
            this.button_ServiceStop.Name = "button_ServiceStop";
            this.button_ServiceStop.Size = new System.Drawing.Size(40, 40);
            this.button_ServiceStop.TabIndex = 7;
            this.button_ServiceStop.UseVisualStyleBackColor = true;
            this.button_ServiceStop.Click += new System.EventHandler(this.Button_ServiceStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(237, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "BrickDaemon is currently: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 49);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // sc
            // 
            this.sc.ServiceName = "Brick Daemon";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button_ServiceRestart);
            this.panel1.Controls.Add(this.button_ServiceStop);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button_ServiceStart);
            this.panel1.Location = new System.Drawing.Point(12, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 90);
            this.panel1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(389, 260);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "BrickDaemonServiceManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TFTryIconMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon TFTrayIcon;
        private System.Windows.Forms.ContextMenuStrip TFTryIconMenu;
        private System.Windows.Forms.ToolStripMenuItem BrickDaemon;
        private System.Windows.Forms.ToolStripMenuItem startServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logViewerToolStripMenuItem;
        private System.Windows.Forms.Button button_ServiceRestart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_ServiceStart;
        private System.Windows.Forms.Button button_ServiceStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.ServiceProcess.ServiceController sc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem programmBeendenToolStripMenuItem;
    }
}

