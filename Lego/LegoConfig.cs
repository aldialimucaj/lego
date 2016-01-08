using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego
{
    class LegoConfig
    {
        public List<LegoWindow> Windows { get; set; }
        public String Shortcut { get; set; }
        public Boolean Stick { get; set; }

        public LegoConfig()
        {
            Windows = new List<LegoWindow>();
        }

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
