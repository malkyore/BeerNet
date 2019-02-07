using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class FoodRecipe
    {
        public ObjectId Id { get; set; }
        public string idString
        {
            get
            {
                return Id.ToString();
            }
        }
        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("ingredientAdditions")]
        public List<IngredientAddition> ingredientAdditions { get; set; }

        [BsonElement("instructions")]
        public string instructions { get; set; }

        [BsonElement("notes")]
        public string notes { get; set; }
    }
}
