using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class ExerciseBase
    {
        [BsonElement("idString")]
        public string idString;
        [BsonElement("name")]
        public String name;
        [BsonElement("Muscles")]
        public List<MuscleBase> Muscles;
        [BsonElement("ShowWeight")]
        public Boolean ShowWeight;
        [BsonElement("ShowTime")]
        public Boolean ShowTime;
        [BsonElement("ShowReps")]
        public Boolean ShowReps;
    }
}
