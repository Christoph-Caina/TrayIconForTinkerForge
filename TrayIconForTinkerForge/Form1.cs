using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.ServiceProcess;
using System.Security.Principal;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace TrayIconForTinkerForge
{
    public partial class Form1 : Form
    {
        ResourceManager res_man;

        //=============================================================================================================
        public Form1()
        {
            InitializeComponent();
            res_man = new ResourceManager(Assembly.GetCallingAssembly().EntryPoint.DeclaringType.Namespace.ToString() + "." + CultureInfo.CurrentUICulture.ThreeLetterISOLanguageName, Assembly.GetExecutingAssembly());

            label1.Text = res_man.GetString("_BrickStatusDisplay");

            TFTrayIcon.Visible = true;

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
            label2.Text = res_man.GetString("_detecting");
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
            if (RunningAsAdmin())
            {
                if (!DoServiceAction("start"))
                {
                    MessageBox.Show(res_man.GetString("_errorDuringStartOfService"));
                }
            }
            else
            {
                Elevate();
                if (!DoServiceAction("start"))
                {
                    MessageBox.Show(res_man.GetString("_errorDuringStartOfService"));
                }
                Close();
            }
        }

        //=============================================================================================================
        private void Button_ServiceStop_Click(object sender, EventArgs e)
        {
            if (RunningAsAdmin())
            {
                if (!DoServiceAction("stop"))
                {
                    MessageBox.Show(res_man.GetString("_errorDuringStopOfService"));
                }
            }
            else
            {
                Elevate();
                Close();
            }
        }

        //=============================================================================================================
        private void Button_ServiceRestart_Click(object sender, EventArgs e)
        {
            if (RunningAsAdmin())
            {
                if (!DoServiceAction("restart"))
                {
                    MessageBox.Show(res_man.GetString("_errorDuringReStartOfService"));
                }
            }
            else
            {
                Elevate();
                Close();
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
                TFTrayIcon.Icon = Properties.Resources.TF_stopped;
            }
            else if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.StartPending)
            {
                button_ServiceStart.Enabled = false;
                button_ServiceStop.Enabled = true;
                button_ServiceRestart.Enabled = true;

                startServiceToolStripMenuItem.Enabled = false;
                stopServiceToolStripMenuItem.Enabled = true;

                label2.ForeColor = Color.DarkGreen;
                TFTrayIcon.Icon = Properties.Resources.TF_running;
            }
            
            label2.Text = sc.Status.ToString();
        }

        //=============================================================================================================
        private void StartServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RunningAsAdmin())
            {
                if (!DoServiceAction("start"))
                {
                    MessageBox.Show(res_man.GetString("_errorDuringStartOfService"));
                }
            }
            else
            {
                Elevate();
                Close();
            }
        }

        //=============================================================================================================
        private void StopServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RunningAsAdmin())
            {
                if (!DoServiceAction("stop"))
                {
                    MessageBox.Show(res_man.GetString("_errorDuringStopOfService"));
                }
            }
            else
            {
                Elevate();
                Close();
            }
        }

        //=============================================================================================================
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
            }
        }

        //=============================================================================================================
        private void TFTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
            }

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

                                TFTrayIcon.Icon = Properties.Resources.TF_stopped;

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

                                TFTrayIcon.Icon = Properties.Resources.TF_running;

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

        //=============================================================================================================
        private void ShowBaloon()
        {
            if (sc.Status == ServiceControllerStatus.Stopped || sc.Status == ServiceControllerStatus.StopPending)
            {
                TFTrayIcon.BalloonTipTitle = res_man.GetString("_BrickDeamonIsStoppedTitle");
                TFTrayIcon.BalloonTipText = res_man.GetString("_BrickDeamonIsStoppedText");   // "Um weiterhin mit deinem Brick-Stapel kommunizieren zu können, muss der Dienst wieder gestartet werden!";
            }

            else if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.StartPending)
            {
                TFTrayIcon.BalloonTipTitle = res_man.GetString("_BrickDeamonIsStartedTitle"); // "BrickDaemon Service ist gestartet!";
                TFTrayIcon.BalloonTipText = res_man.GetString("_BrickDeamonIsStartedText");   // "Du kannst nun eine Verbindung mit deinem Brick-Stapel aufbauen.";
            }

            TFTrayIcon.ShowBalloonTip(2000);
        }

        //=============================================================================================================
        internal static bool RunningAsAdmin()
        {
            var principle = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return principle.IsInRole(WindowsBuiltInRole.Administrator);
        }

        //=============================================================================================================
        private static bool Elevate()
        {
            var SelfProc = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Application.ExecutablePath,
                Verb = "runas"
            };
            try
            {
                Process.Start(SelfProc);
                return true;
            }
            catch
            {
                MessageBox.Show("Unable to elevate!");
                return false;
            }
        }
    }

}
