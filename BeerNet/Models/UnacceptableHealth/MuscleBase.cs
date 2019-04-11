using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class MuscleBase
    {
        [BsonElement("idString")]
        public string idString;
        [BsonElement("name")]
        public String name;
    }
}
