using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    [BsonIgnoreExtraElements]
    public class recipe
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
        [BsonElement("lastModifiedGuid")]
        public Guid lastModifiedGuid { get; set; }
        [BsonElement("createdByUserID")]
        public string createdByUserID { get; set; }
        [BsonElement("groupID")]
        public string groupID { get; set; }
        [BsonElement("isGroupEditable")]
        public bool isGroupEditable { get; set; }
        [BsonElement("isPublic")]
        public bool isPublic { get; set; }
        [BsonElement("deleted")]
        public bool deleted { get; set; }
        [BsonElement("description")]
        public string description { get; set; }
        [BsonElement("recipeStats")]
        public RecipeStatistics recipeStats { get; set; }
        [BsonElement("recipeParameters")]
        public RecipeParameters recipeParameters { get; set; }
        [BsonElement("version")]
        public double version { get; set; }
        [BsonElement("clonedFrom")]
        public string clonedFrom { get; set; }
        [BsonElement("hidden")]
        public string hidden { get; set; }
        [BsonElement("hops")]
        public List<hopAddition> hops { get; set; }
        [BsonElement("fermentables")]
        public List<fermentableAddition> fermentables { get; set; }
        [BsonElement("yeasts")]
        public List<yeastAddition> yeasts { get; set; }
        [BsonElement("adjuncts")]
        public List<adjunctAddition> adjuncts { get; set; }
        [BsonElement("style")]
        public styleBase style { get; set; }
        [BsonElement("boilVolume")]
        public double boilVolume { get; set; }
        [BsonElement("equipmentProfile")]
        public equipmentProfileBase equipmentProfile {get;set;}

        public double grainsInPounds()
        {
            double lbs = 0;
            foreach (fermentableAddition fa in fermentables)
            {
                lbs += fa.weight;
            }

            return lbs;
        }
    }
}
