using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class fermentableAddition
    {
       // [BsonElement("Id")]
       // public string Id { get; set; }
        //[BsonElement("recipeID")]
        //public string recipeID { get; set; }
        [BsonElement("fermentableID")]
        public string fermentableID { get; set; }
        [BsonElement("use")]
        public string use { get; set; }
        [BsonElement("weight")]
        public float weight { get; set; }
        [BsonElement("fermentable")]
        public fermentable fermentable { get; set; }
    }
}
