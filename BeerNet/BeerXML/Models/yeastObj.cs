using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.BeerXML.Models
{
    public class yeastObj
    {
        [BsonElement("LABORATORY")]
        public string LABORATORY { get; set; }
        [BsonElement("NAME")]
        public string NAME { get; set; }
        [BsonElement("TYPE")]
        public string TYPE { get; set; }
        [BsonElement("FORM")]
        public string FORM { get; set; }
        [BsonElement("ATTENUATION")]
        public double? ATTENUATION { get; set; }
    }
}
