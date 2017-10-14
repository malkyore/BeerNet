using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BeerNet.Models
{
    public class hopbase
    {
        [BsonElement("idString")]
        public string idString { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("aau")]
        public double aau { get; set; }
    }
}
