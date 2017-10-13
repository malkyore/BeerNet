using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class recipe
    {
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("style")]
        public string style { get; set; }
        [BsonElement("description")]
        public string description { get; set; }
        [BsonElement("abv")]
        public double abv { get; set; }
        [BsonElement("ibu")]
        public double ibu { get; set; }
        [BsonElement("fg")]
        public double fg { get; set; }
        [BsonElement("og")]
        public double og { get; set; }
        [BsonElement("srm")]
        public double srm { get; set; }
        [BsonElement("version")]
        public double version { get; set; }
        [BsonElement("parentRecipe")]
        public string parentRecipe { get; set; }
        [BsonElement("clonedFrom")]
        public string clonedFrom { get; set; }
        [BsonElement("hidden")]
        public string hidden { get; set; }
        [BsonElement("hops")]
        public List<hop> hops { get; set; }
        //[BsonElement("fermentables")]
        //public List<fermentable> fermentables { get; set; }
        //[BsonElement("yeasts")]
        //public List<yeast> yeasts { get; set; }
        //[BsonElement("adjuncts")]
        //public List<adjunct> adjuncts { get; set; }
        [BsonElement("test")]
        public string test { get; set; }
        [BsonElement("styleID")]
        public string styleID { get; set; }
        
    }
}
