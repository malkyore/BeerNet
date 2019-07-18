using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.BeerXML.Models
{
    public class miscObj
    {
        [BsonElement("NAME")]
        public string NAME { get; set; }
        [BsonElement("USE")]
        public string USE { get; set; }
        [BsonElement("TIME")]
        public double? TIME { get; set; }
        [BsonElement("AMOUNT")]
        public double? AMOUNT { get; set; }

        //bool
        [BsonElement("AMOUNT_IS_WEIGHT")]
        public bool? AMOUNT_IS_WEIGHT { get; set; }

        [BsonElement("NOTES")]
        public string NOTES { get; set; }
        [BsonElement("DISPLAY_AMOUNT")]
        public string DISPLAY_AMOUNT { get; set; }
        [BsonElement("DISPLAY_TIME")]
        public string DISPLAY_TIME { get; set; }
    }
}
