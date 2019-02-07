using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class Ingredient : IngredientBase
    {
        public ObjectId Id { get; set; }
        public new string idString
        {
            get
            {
                return Id.ToString();
            }
        }
    }
}
