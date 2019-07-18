using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.BeerXML.Models
{
    public class styleObj
    {
        [BsonElement("STYLE_GUIDE")]
        public string STYLE_GUIDE { get; set; }
        [BsonElement("VERSION")]
        public double? VERSION { get; set; }
        [BsonElement("NAME")]
        public string NAME { get; set; }
        [BsonElement("STYLE_LETTER")]
        public string STYLE_LETTER { get; set; }
        [BsonElement("CATEGORY_NUMBER")]
        public double? CATEGORY_NUMBER { get; set; }
        [BsonElement("TYPE")]
        public string TYPE { get; set; }
        [BsonElement("OG_MIN")]
        public double? OG_MIN { get; set; }
        [BsonElement("OG_MAX")]
        public double? OG_MAX { get; set; }
        [BsonElement("FG_MIN")]
        public double? FG_MIN { get; set; }
        [BsonElement("FG_MAX")]
        public double? FG_MAX { get; set; }
        [BsonElement("IBU_MIN")]
        public double? IBU_MIN { get; set; }
        [BsonElement("IBU_MAX")]
        public double? IBU_MAX { get; set; }
        [BsonElement("COLOR_MIN")]
        public double? COLOR_MIN { get; set; }
        [BsonElement("COLOR_MAX")]
        public double? COLOR_MAX { get; set; }
        [BsonElement("ABV_MIN")]
        public double? ABV_MIN { get; set; }
        [BsonElement("ABV_MAX")]
        public double? ABV_MAX { get; set; }
    }
}
