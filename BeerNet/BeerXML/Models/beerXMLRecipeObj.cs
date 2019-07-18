using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.BeerXML.Models
{
    public class RECIPE
    {
        [BsonElement("NAME")]
        public string NAME { get; set; }
        [BsonElement("STYLE")]
        public styleObj STYLE { get; set; }
       // [BsonElement("FERMENTABLE")]
       // public List<fermentableObj> FERMENTABLE { get; set; }
       // [BsonElement("HOPS")]
      //  public List<hopObj> HOPS { get; set; } 
      //  [BsonElement("YEASTS")]
      //  public List<yeastObj> YEASTS { get; set; }
       // [BsonElement("MISCS")]
       // public List<miscObj> MISCS { get; set; }
        [BsonElement("TYPE")]
        public string TYPE { get; set; }
        [BsonElement("BREWER")]
        public string BREWER { get; set; }
        [BsonElement("BATCH_SIZE")]
        public double? BATCH_SIZE { get; set; }
        [BsonElement("BOIL_SIZE")]
        public double? BOIL_SIZE { get; set; }
        [BsonElement("BOIL_TIME")]
        public double? BOIL_TIME { get; set; }
        [BsonElement("EFFICIENCY")]
        public double? EFFICIENCY { get; set; }
    }
}
