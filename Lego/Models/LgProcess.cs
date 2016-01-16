using Newtonsoft.Json;
using System.Diagnostics;
using System.ComponentModel;

namespace Lego.Models
{
    public class LgProcess : INotifyPropertyChanged
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

        /// <summary>
        /// Create LgProcess form a windows process
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public static LgProcess FromProcess(Process process)
        {
            LgProcess p = new LgProcess(process.ProcessName, process.MainModule.FileName, process.ProcessName, process.StartInfo.Arguments);
            p.WinProcess = process;
            return p;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
