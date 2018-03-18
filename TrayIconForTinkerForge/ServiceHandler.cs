using System;
using System.ServiceProcess;

namespace TrayIconForTinkerForge
{    class ServiceHandler
    {
        ServiceController sc = new ServiceController("Brick Daemon");

        public bool DoServiceAction(string ServiceCommand)
        {
            bool returnVar = false;

            switch (ServiceCommand)
            {
                case "start":
                    try
                    {
                        if (sc.Status != ServiceControllerStatus.Running || sc.Status != ServiceControllerStatus.StartPending)
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
                    catch (Exception)
                    {
                        returnVar = false;
                    }
                    break;

                case "stop":
                    try
                    {
                        if (sc.Status != ServiceControllerStatus.Stopped || sc.Status != ServiceControllerStatus.StopPending)
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
                    catch (Exception)
                    {
                        returnVar = false;
                    }
                    break;

                case "restart":
                    try
                    {
                        if (sc.Status != ServiceControllerStatus.Running || sc.Status != ServiceControllerStatus.StartPending)
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

            return returnVar;
        }
    }
}
