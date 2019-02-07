using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class IngredientAddition
    {
        [BsonElement("IngredientID")]
        public string IngredientID { get; set; }
        [BsonElement("amount")]
        public float amount { get; set; }
        [BsonElement("measure")]
        public string measure { get; set; }
        [BsonElement("Ingredient")]
        public Ingredient ingredient { get; set; }
    }
}
