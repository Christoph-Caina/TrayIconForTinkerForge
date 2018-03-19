using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.ServiceProcess;

namespace TrayIconForTinkerForge
{
    public partial class Form1 : Form
    {
        //=============================================================================================================
        public Form1()
        {
            InitializeComponent();
            TFTrayIcon.Visible = true;
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;

            FormClosing += Form1_FormClosing;               // Form-Closing

            ShowBaloon();

            timer1.Interval = 1000;

            timer1.Enabled = true;
            timer1.Start();
        }

        //=============================================================================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
            label2.Text = "detecting...";
        }

        //=============================================================================================================
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();
        }

        //=============================================================================================================
        private void Button_ServiceStart_Click(object sender, EventArgs e)
        {
            if (!DoServiceAction("start"))
            {
                MessageBox.Show("Fehler beim Starten");
            }
        }

        //=============================================================================================================
        private void Button_ServiceStop_Click(object sender, EventArgs e)
        {
            if (!DoServiceAction("stop"))
            {
                MessageBox.Show("Fehler beim Stoppen");
            }
        }

        //=============================================================================================================
        private void Button_ServiceRestart_Click(object sender, EventArgs e)
        {
            if (!DoServiceAction("restart"))
            {
                MessageBox.Show("Fehler beim Neustarten");
            }
        }

        //=============================================================================================================
        private void Button_ServicePause_Click(object sender, EventArgs e)
        {

        }

        //=============================================================================================================
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("services.msc");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //=============================================================================================================
        private void CheckServiceState()
        {
            sc.Refresh();

            if (sc.Status == ServiceControllerStatus.Stopped || sc.Status == ServiceControllerStatus.StopPending)
            {
                button_ServiceStart.Enabled = true;
                button_ServiceStop.Enabled = false;
                button_ServiceRestart.Enabled = false;

                startServiceToolStripMenuItem.Enabled = true;
                stopServiceToolStripMenuItem.Enabled = false;

                label2.ForeColor = Color.DarkRed;
                TFTrayIcon.Icon = TrayIconForTinkerForge.Properties.Resources.TF_stopped;
            }
            else if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.StartPending)
            {
                button_ServiceStart.Enabled = false;
                button_ServiceStop.Enabled = true;
                button_ServiceRestart.Enabled = true;

                startServiceToolStripMenuItem.Enabled = false;
                stopServiceToolStripMenuItem.Enabled = true;

                label2.ForeColor = Color.DarkGreen;
                TFTrayIcon.Icon = TrayIconForTinkerForge.Properties.Resources.TF_running;
            }

            label2.Text = sc.Status.ToString();
        }

        //=============================================================================================================
        private void StartServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DoServiceAction("start"))
            {
                MessageBox.Show("Fehler beim Starten");
            }
        }

        //=============================================================================================================
        private void StopServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DoServiceAction("stop"))
            {
                MessageBox.Show("Fehler beim Stoppen");
            }
        }

        //=============================================================================================================
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                TFTrayIcon.Visible = true;
            }
        }

        //=============================================================================================================
        private void TFTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }

            ShowInTaskbar = false;
        }

        //=============================================================================================================
        private void ProgrammBeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //=============================================================================================================
        private void LogViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("C:\\Program Files (x86)\\Tinkerforge\\Brickd\\LogViewer.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //=============================================================================================================
        private void Timer1_Tick(object sender, EventArgs e)
        {
            CheckServiceState();
        }

        //=============================================================================================================
        private void ShowBallonTip()
        {
            TFTrayIcon.ShowBalloonTip(10000);
        }

        //=============================================================================================================
        private bool DoServiceAction(string ServiceCommand)
        {
            bool returnVar = false;

            switch (ServiceCommand)
            {
                case "stop":
                    try
                    {
                        if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.StartPending)
                        {
                            sc.Stop();
                            sc.WaitForStatus(ServiceControllerStatus.Stopped);

                            TFTrayIcon.Icon = TrayIconForTinkerForge.Properties.Resources.TF_stopped;

                            //TFTrayIcon.BalloonTipTitle = "BrickDaemon Service ist gestoppt!";
                            //TFTrayIcon.BalloonTipText = "Um weiterhin mit deinem Brick-Stapel kommunizieren zu können, muss der Dienst wieder gestartet werden!";

                            returnVar = true;
                        }
                        else
                        {
                            returnVar = false;
                        }
                    }
                    catch (Exception)
                    {
                        returnVar = false;
                    }
                    break;

                case "start":
                    try
                    {
                        if (sc.Status == ServiceControllerStatus.Stopped || sc.Status == ServiceControllerStatus.StopPending)
                        {
                            sc.Start();
                            sc.WaitForStatus(ServiceControllerStatus.Running);

                            TFTrayIcon.Icon = TrayIconForTinkerForge.Properties.Resources.TF_running;

                            //TFTrayIcon.BalloonTipTitle = "BrickDaemon Service ist gestartet!";
                            //TFTrayIcon.BalloonTipText = "Du kannst nun eine Verbindung mit deinem Brick-Stapel aufbauen.";

                            returnVar = true;
                        }
                        else
                        {
                            returnVar = false;
                        }
                    }
                    catch (Exception)
                    {
                        returnVar = false;
                    }
                    break;

                case "restart":
                    try
                    {
                        if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.StartPending)
                        {
                            sc.Stop();
                            sc.WaitForStatus(ServiceControllerStatus.Stopped);
                            sc.Start();
                            sc.WaitForStatus(ServiceControllerStatus.Running);

                            returnVar = true;
                        }
                        else
                        {
                            returnVar = false;
                        }
                    }
                    catch (Exception)
                    {
                        returnVar = false;
                    }
                    break;
            }
            //TFTrayIcon.ShowBalloonTip(2000);
            ShowBaloon();
            return returnVar;
        }

        private void ShowBaloon()
        {
            if (sc.Status == ServiceControllerStatus.Stopped || sc.Status == ServiceControllerStatus.StopPending)
            {
                TFTrayIcon.BalloonTipTitle = "BrickDaemon Service ist gestoppt!";
                TFTrayIcon.BalloonTipText = "Um weiterhin mit deinem Brick-Stapel kommunizieren zu können, muss der Dienst wieder gestartet werden!";
            }

            else if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.StartPending)
            {
                TFTrayIcon.BalloonTipTitle = "BrickDaemon Service ist gestartet!";
                TFTrayIcon.BalloonTipText = "Du kannst nun eine Verbindung mit deinem Brick-Stapel aufbauen.";
            }

            TFTrayIcon.ShowBalloonTip(2000);
        }
    }
}
