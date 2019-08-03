using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    [BsonIgnoreExtraElements]
    public class YeastBase
    {
        [BsonElement("idString")]
        public string idString { get; set; }
        [BsonElement("createdByUserId")]
        public string createdByUserId { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("lab")]
        public string lab { get; set; }
        [BsonElement("attenuation")]
        public double attenuation { get; set; }
        [BsonElement("beertype")]
        public string beertype { get; set; }
        [BsonElement("form")]
        public string form { get; set; }
        [BsonElement("minTemperature")]
        public double minTemperature { get; set; }
        [BsonElement("maxTemperature")]
        public double maxTemperature { get; set; }
        [BsonElement("flocculation")]
        public string flocculation { get; set; }
        [BsonElement("notes")]
        public string notes { get; set; }
    }
}
