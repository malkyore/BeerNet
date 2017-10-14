using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class hopAddition
    {
       // [BsonElement("Id")]
      //  public string Id { get; set; }
        //[BsonElement("recipeID")]
        //public string recipeID { get; set; }
        [BsonElement("hopID")]
        public string hopID { get; set; }
        [BsonElement("amount")]
        public float amount { get; set; }
        [BsonElement("type")]
        public string type { get; set; }
        [BsonElement("time")]
        public float time { get; set; }
        [BsonElement("hop")]
        public hopbase hop { get; set; }
    }
}
