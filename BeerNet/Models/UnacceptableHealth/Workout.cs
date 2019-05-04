using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class Workout
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
        public string name;
        [BsonElement("WorkoutPlan")]
        public WorkoutPlanBase WorkoutPlan;
        [BsonElement("Notes")]
        public String Notes;
        [BsonElement("Date")]
        public DateTime Date;
        [BsonElement("StartTime")]
        public long StartTime;
        [BsonElement("EndTime")]
        public long EndTime;
    }
}
