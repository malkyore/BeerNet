using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class RecipeStatistics
    {
        public double abv { get; set; }
        public double ibu { get; set; }
        public double fg { get; set; }
        public double og { get; set; }
        public double srm { get; set; }
    }
}
