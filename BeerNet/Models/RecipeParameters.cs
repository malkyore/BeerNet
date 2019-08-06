using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    [BsonIgnoreExtraElements]
    public class RecipeParameters
    {
        [BsonElement("ibuCalcType")]
        public string ibuCalcType { get; set; }
        [BsonElement("fermentableCalcType")]
        public string fermentableCalcType { get; set; }
        [BsonElement("ibuBoilTimeCurveFit")]
        public double ibuBoilTimeCurveFit { get; set; }
        [BsonElement("gristRatio")]
        public double gristRatio { get; set; } //ratio of water to grain pounds
        [BsonElement("initialMashTemp")]
        public double initialMashTemp { get; set; } //initial temperature of grains before starting the mash
        [BsonElement("targetMashTemp")]
        public double targetMashTemp { get; set; }
    }
}
