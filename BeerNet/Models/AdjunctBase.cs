using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class AdjunctBase
    {
        [BsonElement("idString")]
        public string idString { get; set; }
        [BsonElement("createdById")]
        public string createdById { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
    }
}
