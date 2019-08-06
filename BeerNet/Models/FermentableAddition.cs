using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    [BsonIgnoreExtraElements]
    public class fermentableAddition
    {
        [BsonElement("additionGuid")]
        public string additionGuid { get; set; }
        [BsonElement("weight")]
        public double weight { get; set; }
        [BsonElement("fermentable")]
        public fermentable fermentable { get; set; }
    }
}
