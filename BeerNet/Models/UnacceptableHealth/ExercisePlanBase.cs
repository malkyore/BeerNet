using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class ExercisePlanBase
    {
        [BsonElement("idString")]
        public string idString;
        [BsonElement("name")]
        public String name;
        [BsonElement("Exercise")]
        public ExerciseBase Exercise;
        [BsonElement("Order")]
        public int Order;
        [BsonElement("Reps")]
        public int Reps;
        [BsonElement("Sets")]
        public int Sets;
        [BsonElement("Weight")]
        public decimal Weight;
        [BsonElement("Seconds")]
        public int Seconds;
    }
}
