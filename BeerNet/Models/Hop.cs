using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BeerNet.Models
{
    public class hop
    {
        public ObjectId Id {get;set;}
        public string idString
        {
            get
            {
                return Id.ToString();
            }
        }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("aau")]
        public double aau { get; set; }
    }
}
