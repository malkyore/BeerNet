using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    [BsonIgnoreExtraElements]
    public class styleBase
    {
        //Info
        [BsonElement("idString")]
        public string idString { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("category")]
        public string category { get; set; }
        [BsonElement("description")]
        public string description { get; set; }
        [BsonElement("profile")]
        public string profile { get; set; }
        [BsonElement("ingredients")]
        public string ingredients { get; set; }
        [BsonElement("examples")]
        public string examples { get; set; }

        //Stats Ranges
        [BsonElement("minOG")]
        public double minOG { get; set; }
        [BsonElement("maxOG")]
        public double maxOG { get; set; }
        [BsonElement("minFG")]
        public double minFG { get; set; }
        [BsonElement("maxFG")]
        public double maxFG { get; set; }
        [BsonElement("minIBU")]
        public double minIBU { get; set; }
        [BsonElement("maxIBU")]
        public double maxIBU { get; set; }
        [BsonElement("minCarb")]
        public double minCarb { get; set; }
        [BsonElement("maxCarb")]
        public double maxCarb { get; set; }
        [BsonElement("minColor")]
        public double minColor { get; set; }
        [BsonElement("maxColor")]
        public double maxColor { get; set; }
        [BsonElement("minABV")]
        public double minABV { get; set; }
        [BsonElement("maxABV")]
        public double maxABV { get; set; }
    }
}
