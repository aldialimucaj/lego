using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego
{
    class LgConfig
    {
        public List<LgWindow> Windows { get; set; }
        public String Shortcut { get; set; }
        public Boolean Stick { get; set; }

        public LgConfig()
        {
            Windows = new List<LgWindow>();
        }


        internal Boolean StartProcesses()
        {
            Boolean allOk = true;
            foreach (LgWindow m in Windows)
            {
                allOk &= LgProcessManager.Start(m.Process);
            }

            return allOk;
        }


        internal Boolean RepositionWindows()
        {
            Boolean allOk = true;
            foreach (LgWindow m in Windows)
            {
                allOk &= LgProcessManager.Reposition(m);
            }

            return allOk;
        }

        internal Boolean AddWindow(LgPoint point)
        {
            Process p = LgProcessManager.GetProcessAtCoordiante(point);
            LgProcess process = LgProcess.FromProcess(p);
            LgRectangle rec = LgProcessManager.GetWindowRectange(process);

            LgWindow window = new LgWindow(rec.GetTopLeft(), rec.GetSize(), process);

            Console.WriteLine(window);
            return true; // differ between use cases
        }

        internal Boolean WriteToFile()
        {
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"e:\temp\config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, this);
            }
            return true;
        }

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);


    }
}
