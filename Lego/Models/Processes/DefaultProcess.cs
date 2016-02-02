using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego.Models.Processes
{
    class DefaultProcess : IProcess
    {
        ProcessStartInfo Info { get; set; }

        public DefaultProcess(LgProcess process)
        {
            Info = new ProcessStartInfo(process.FullPath);
        }

        public void AddArgument(string arg)
        {
            Info.Arguments += " " + arg;
        }

        public ProcessStartInfo GetStartInfo()
        {
            return Info;
        }
    }
}
