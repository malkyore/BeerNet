using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class IngredientBase
    {
        [BsonElement("idString")]
        public string idString { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
    }
}
