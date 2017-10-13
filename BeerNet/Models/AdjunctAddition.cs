using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class adjunctAddition
    {
        public string id { get; set; }
        public string recipeID { get; set; }
        public string adjunctID { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
        public float time { get; set; }
        public string timeUnit { get; set; }
        public string type { get; set; }
        public adjunct adjunct { get; set; }
    }
}
