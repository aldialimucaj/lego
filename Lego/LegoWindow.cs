using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego
{
    class LegoWindow
    {

        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public Process Process { get; }

        public LegoWindow(Point top, Point bottom, Process process )
        {
            TopLeft = top;
            BottomRight = bottom;
            Process = process;
        }

        public JObject ToJson() => new JObject() {
            ["top"] = TopLeft.AsToken(),
            ["bottom"] = BottomRight.AsToken(),
            ["process"] = Process.AsToken()
        };

        public override string ToString() => $"{TopLeft}, {BottomRight} - {Process}";
        
    }
}
