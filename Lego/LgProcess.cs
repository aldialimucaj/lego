using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Path { get; set; }

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

        public LgProcess(string name, string path, string filename, string args)
        {
            Name = name;
            Path = path;
            Filename = filename;
            Arguments = args;
        }
        
        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
