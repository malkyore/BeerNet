using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class FermentableBase
    {
        //Required 
        [BsonElement("idString")]
        public string idString { get; set; }
        [BsonElement("createdByUserId")]
        public string createdByUserId { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("yield")]
        public float yield { get; set; }
        [BsonElement("color")]
        public float color { get; set; }
        [BsonElement("type")]
        public string type { get; set; }

        //not required
        [BsonElement("maltster")]
        public string maltster { get; set; }
        [BsonElement("origin")]
        public string origin { get; set; }
        [BsonElement("coarse_fine_diff")]
        public float coarse_fine_diff { get; set; }
        [BsonElement("moisture")]
        public float moisture { get; set; }
        [BsonElement("diastatic_power")]
        public float diastatic_power { get; set; }
        [BsonElement("protein")]
        public float protein { get; set; }
        [BsonElement("notes")]
        public string notes { get; set; }
    }
}
