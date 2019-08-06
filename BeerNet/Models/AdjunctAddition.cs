using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    [BsonIgnoreExtraElements]
    public class adjunctAddition
    {
        [BsonElement("additionGuid")]
        public string additionGuid { get; set; }
        [BsonElement("amount")]
        public double amount { get; set; }
        [BsonElement("unit")]
        public string unit { get; set; }
        [BsonElement("time")]
        public double time { get; set; }
        [BsonElement("timeUnit")]
        public string timeUnit { get; set; }
        [BsonElement("type")]
        public string type { get; set; }
        [BsonElement("adjunct")]
        public adjunct adjunct { get; set; }
    }
}
