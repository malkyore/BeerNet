using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class hopAddition
    {
        public string recipeID { get; set; }
        public string hopID { get; set; }
        public float amount { get; set; }
        public string type { get; set; }
        public float time { get; set; }
        public string id { get; set; }
        public hop hop { get; set; }
    }
}
