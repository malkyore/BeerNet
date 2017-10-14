using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class RecipeParameters
    {
        [BsonElement("ibuCalcType")]
        public string ibuCalcType { get; set; }
        [BsonElement("fermentableCalcType")]
        public string fermentableCalcType { get; set; }
        [BsonElement("ibuBoilTimeCurveFit")]
        public double ibuBoilTimeCurveFit { get; set; }
        [BsonElement("intoFermenterVolume")]
        public double intoFermenterVolume { get; set; }
    }
}
