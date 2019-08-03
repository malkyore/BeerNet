using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BeerNet.Models
{
    //TODO: We need to document what the shit this hop and hopbase stuff is. A year(ish) later and all I remember was it was very confusing even when we made this.
    [BsonIgnoreExtraElements]
    public class hopbase
    {
        [BsonElement("idString")]
        public string idString { get; set; }
        [BsonElement("createdByUserId")]
        public string createdByUserId { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("aau")]
        public double aau { get; set; }
        [BsonElement("beta")]
        public double beta { get; set; }
        [BsonElement("notes")]
        public string notes { get; set; }
        [BsonElement("type")]
        public string type { get; set; }

        //random weird stuff
        [BsonElement("hsi")]
        public double hsi { get; set; }
        [BsonElement("origin")]
        public string origin { get; set; }
        [BsonElement("substitues")]
        public string substitutes { get; set; }
        [BsonElement("humulene")]
        public double humulene { get; set; }
        [BsonElement("caryophyllene")]
        public double caryophyllene { get; set; }
        [BsonElement("cohumulone")]
        public double cohumulone { get; set; }
        [BsonElement("myrcene")]
        public double myrcene { get; set; }
    }
}
