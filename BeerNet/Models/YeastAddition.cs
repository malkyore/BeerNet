using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class yeastAddition
    {
        public string id { get; set; }
        public string recipeID { get; set; }
        public string yeastID { get; set; }
        public yeast yeast { get; set; }
    }
}
