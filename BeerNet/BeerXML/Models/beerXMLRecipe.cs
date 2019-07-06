using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerNet.Models;

namespace BeerNet.BeerXML.Models
{
    /// <summary>
    /// Beer XML is a list of recipes even if there's only 1 recipe...
    /// so this is a thing.
    /// </summary>
    public class beerXMLRecipe
    {
        [BsonElement("RECIPES")]
        public List<recipe> RECIPES { get; set; }
    }
}
