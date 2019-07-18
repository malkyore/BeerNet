using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.BeerXML.Models
{
    public class fermentableObj
    {
        [BsonElement("NAME")]
        public string NAME { get; set; }
        [BsonElement("ORIGIN")]
        public string ORIGIN { get; set; }
        [BsonElement("TYPE")]
        public string TYPE { get; set; }
        [BsonElement("YIELD")]
        public double? YIELD { get; set; }
        [BsonElement("AMOUNT")]
        public double? AMOUNT { get; set; }
        [BsonElement("DISPLAY_AMOUNT")]
        public string DISPLAY_AMOUNT { get; set; }
        [BsonElement("POTENTIAL")]
        public double? POTENTIAL { get; set; }
        [BsonElement("COLOR")]
        public double? COLOR { get; set; }
        [BsonElement("DISPLAY_COLOR")]
        public string DISPLAY_COLOR { get; set; }

        //I don't know what data type the rest of these
        //is supposed to be so I made them strings...
        [BsonElement("ADD_AFTER_BOIL")]
        public string ADD_AFTER_BOIL { get; set; }
        [BsonElement("COARSE_FINE_DIFF")]
        public string COARSE_FINE_DIFF { get; set; }
        [BsonElement("MOISTURE")]
        public string MOISTURE { get; set; }
        [BsonElement("DIASTATIC_POWER")]
        public string DIASTATIC_POWER { get; set; }
        [BsonElement("PROTEIN")]
        public string PROTEIN { get; set; }
        [BsonElement("MAX_IN_BATCH")]
        public string MAX_IN_BATCH { get; set; }
        [BsonElement("RECOMMEND_MASH")]
        public string RECOMMEND_MASH { get; set; }
        [BsonElement("IBU_GAL_PER_LB")]
        public string IBU_GAL_PER_LB { get; set; }

        //This one I assume is right though...
        [BsonElement("NOTES")]
        public string NOTES { get; set; }
    }
}
