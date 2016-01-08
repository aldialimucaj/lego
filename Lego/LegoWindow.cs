using Newtonsoft.Json;
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
        public Size Size { get; set; }

        public Process Process { get; }

        public LegoWindow(Point top, Point bottom, Process process )
        {
            TopLeft = top;
            BottomRight = bottom;
            Process = process;
        }

        public LegoWindow(Point top, Size size, Process process)
        {
            TopLeft = top;
            Size = size;
            Process = process;
        }



        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);        
    }
}
