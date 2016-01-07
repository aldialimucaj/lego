using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego
{
    class Process
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Arguments { get; set; }

        public JToken AsToken() => JToken.FromObject(this);

        public override string ToString() => $"{Name}";
    }
}
