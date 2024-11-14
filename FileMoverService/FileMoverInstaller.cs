
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace FileMoverService
{
    [RunInstaller(true)]
    public partial class FileMoverInstaller : Installer
    {
        private ServiceProcessInstaller installer;
        private ServiceInstaller serviceInstaller;
        public FileMoverInstaller()
        {
            installer = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalService
            };

            serviceInstaller = new ServiceInstaller
            {
                ServiceName = "FileMoverService",
                DisplayName = "File Mover Service",
                StartType = ServiceStartMode.Automatic
            };

            Installers.Add(installer);
            Installers.Add(serviceInstaller);
        }
    }
}
