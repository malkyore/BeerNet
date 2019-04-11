using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth.CustomReturns
{
    public class ExerciseWithMuscleList
    {
        [BsonElement("Exercise")]
        public Exercise Exercise;
        [BsonElement("Muscles")]
        public IEnumerable<Muscle> Muscles;
    }
}
