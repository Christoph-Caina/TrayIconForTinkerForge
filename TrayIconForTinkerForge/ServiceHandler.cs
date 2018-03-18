using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace TrayIconForTinkerForge
{
    class ServiceHandler
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
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running);

                        returnVar = true;
                    }
                    catch (Exception)
                    {
                        returnVar = false;
                    }
                    break;

                case "stop":
                    try
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped);

                        returnVar = true;
                    }
                    catch (Exception)
                    {
                        returnVar = false;
                    }
                    break;

                case "restart":
                    try
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped);
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running);

                        returnVar = true;
                    }
                    catch (Exception ex)
                    {
                        returnVar = false;
                    }
                    break;
            }

            return returnVar;
        }
    }
}
