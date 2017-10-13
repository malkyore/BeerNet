using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class fermentable
    {
        public string id { get; set; }
        public string name { get; set; }
        public float ppg { get; set; }
        public float color { get; set; }
        public string type { get; set; }
        public string maltster { get; set; }
    }
}
