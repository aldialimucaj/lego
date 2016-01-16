using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego.Models
{
    public class LgSize
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public LgSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
