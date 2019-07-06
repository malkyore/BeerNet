using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.BeerXML.Models
{
    public class hopObj
    {
        [BsonElement("NAME")]
        public string NAME { get; set; }
        [BsonElement("ORIGIN")]
        public string ORIGIN { get; set; }
        [BsonElement("ALPHA")]
        public double? ALPHA { get; set; }
        [BsonElement("BETA")]
        public double? BETA { get; set; }
        [BsonElement("AMOUNT")]
        public double? AMOUNT { get; set; }
        [BsonElement("DISPLAY_AMOUNT")]
        public string DISPLAY_AMOUNT { get; set; }
        [BsonElement("USE")]
        public string USE { get; set; }
        [BsonElement("FORM")]
        public string FORM { get; set; }
        [BsonElement("TIME")]
        public double? TIME { get; set; }
        [BsonElement("DISPLAY_TIME")]
        public string DISPLAY_TIME { get; set; }
        [BsonElement("NOTES")]
        public string NOTES { get; set; }
    }
}
