using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            foreach(LgWindow m in Windows)
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

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);


    }
}
