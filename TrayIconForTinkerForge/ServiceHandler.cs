using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace TrayIconForTinkerForge
{    class ServiceHandler
    {
        ServiceController sc = new ServiceController("Brick Daemon");

        public bool DoServiceAction(string ServiceCommand)
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
                            returnVar = true;
                        }
                        else
                        {
                            returnVar = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
                            returnVar = true;
                        }
                        else
                        {
                            returnVar = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        returnVar = false;
                    }
                    break;
            }

            return returnVar;
        }
    }
}
