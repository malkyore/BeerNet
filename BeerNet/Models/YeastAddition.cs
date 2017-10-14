using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class yeastAddition
    {
       // [BsonElement("Id")]
       // public string Id { get; set; }
        //[BsonElement("recipeID")]
        //public string recipeID { get; set; }
        [BsonElement("yeastID")]
        public string yeastID { get; set; }
        [BsonElement("yeast")]
        public yeast yeast { get; set; }
    }
}
