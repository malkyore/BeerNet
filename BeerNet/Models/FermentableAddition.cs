using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class fermentableAddition
    {
        public string id { get; set; }
        public string recipeID { get; set; }
        public string fermentableID { get; set; }
        public string use { get; set; }
        public float weight { get; set; }
        public fermentable fermentable { get; set; }
    }
}
