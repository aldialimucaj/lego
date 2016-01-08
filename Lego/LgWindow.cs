using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego
{
    class LgWindow
    {

        public LgPoint TopLeft { get; set; }
        public LgSize Size { get; set; }

        public LgProcess Process { get; }

        public LgWindow(LgPoint top, LgPoint bottom, LgProcess process )
        {
            TopLeft = top;
            Process = process;
        }

        public LgWindow(LgPoint top, LgSize size, LgProcess process)
        {
            TopLeft = top;
            Size = size;
            Process = process;
        }



        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);        
    }
}
