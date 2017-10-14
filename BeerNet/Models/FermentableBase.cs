using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class FermentableBase
    {
        [BsonElement("idString")]
        public string idString { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("ppg")]
        public float ppg { get; set; }
        [BsonElement("color")]
        public float color { get; set; }
        [BsonElement("type")]
        public string type { get; set; }
        [BsonElement("maltster")]
        public string maltster { get; set; }
    }
}
