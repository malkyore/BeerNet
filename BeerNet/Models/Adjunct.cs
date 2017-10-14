using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class adjunct
    {
        //public ObjectId Id { get; set; }
        //public string idString
        //  {
        //      get
        //      {
        //          return Id.ToString();
        //      }
        //  }
        [BsonElement("idString")]
        public string idString { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
    }
}
