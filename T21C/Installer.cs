using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T21C
{
    internal class Installer
    {
        public Installer()
        {
            var installer = new Process();
            installer.StartInfo.Verb = "runas";
            installer.StartInfo.FileName = Path.Combine(AppContext.BaseDirectory, "mods/T21C/Installer.bat");
            installer.Start();
        }
    }
}