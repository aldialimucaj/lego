using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego.Models
{
    public class LgPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public LgPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
