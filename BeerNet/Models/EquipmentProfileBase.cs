using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    [BsonIgnoreExtraElements]
    public class equipmentProfileBase 
    {
        [BsonElement("createdByUserId")]
        public string createdByUserId { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("idString")]
        public string idString { get; set; }
        [BsonElement("boilSize")]
        public double boilSize { get; set; }        
        [BsonElement("intoFermenterVolume")]
        public double intoFermenterVolume { get; set; }
        [BsonElement("efficiency")]
        public double efficiency { get; set; }
        [BsonElement("batchSize")]
        public double batchSize { get; set; }
    }
}
