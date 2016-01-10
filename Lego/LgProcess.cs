using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lego
{
    class LgProcess
    {
        /// <summary>
        /// Description of the process
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Path where to find the process
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Filename to be executed
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Arguments to execute the process with
        /// </summary>
        public string Arguments { get; set; }

        /// <summary>
        /// Handle to the process. It is set after execution or during configuration.
        /// </summary>
        [JsonIgnore]
        public IntPtr hwnd { get; set; }
        
        /// <summary>
        /// Windows process
        /// </summary>
        [JsonIgnore]
        public Process WinProcess { get; internal set; }

        public LgProcess(string name, string path, string filename, string args)
        {
            Name = name;
            FullPath = path;
            Filename = filename;
            Arguments = args;
        }

        public static LgProcess FromProcess(Process process)
        {
            LgProcess p = new LgProcess(process.ProcessName, process.MainModule.FileName, process.ProcessName, process.StartInfo.Arguments);
            p.hwnd = process.MainWindowHandle;
            p.WinProcess = process;
            return p;
        }
        
        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
