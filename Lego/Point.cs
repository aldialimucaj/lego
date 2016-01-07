using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public JObject ToJson() => new JObject()
        {
            ["x"] = X,
            ["y"] = Y
        };

        public JToken AsToken() => JToken.FromObject(this);

        public override string ToString() => $"({X}, {Y})";
    }
}
