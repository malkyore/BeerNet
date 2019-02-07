using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BeerNet.Models
{
    //TODO: We need to document what the shit this hop and hopbase stuff is. A year(ish) later and all I remember was it was very confusing even when we made this.
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
