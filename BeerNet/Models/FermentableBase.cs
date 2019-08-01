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
        public double yield { get; set; }
        [BsonElement("color")]
        public double color { get; set; }
        [BsonElement("type")]
        public string type { get; set; }

        //not required
        [BsonElement("maltster")]
        public string maltster { get; set; }
        [BsonElement("origin")]
        public string origin { get; set; }
        [BsonElement("coarse_fine_diff")]
        public double coarse_fine_diff { get; set; }
        [BsonElement("moisture")]
        public double moisture { get; set; }
        [BsonElement("diastatic_power")]
        public double diastatic_power { get; set; }
        [BsonElement("protein")]
        public double protein { get; set; }
        [BsonElement("notes")]
        public string notes { get; set; }
    }
}
