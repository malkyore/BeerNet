using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    [BsonIgnoreExtraElements]
    public class yeastAddition
    {
        [BsonElement("additionGuid")]
        public string additionGuid { get; set; }
        [BsonElement("yeast")]
        public yeast yeast { get; set; }
    }
}
