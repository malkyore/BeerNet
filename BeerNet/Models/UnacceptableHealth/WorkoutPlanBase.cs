using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class WorkoutPlanBase
    {
        [BsonElement("idString")]
        public string idString;
        [BsonElement("name")]
        public string name;
        [BsonElement("WorkoutType")]
        public WorkoutTypeBase WorkoutType;
        [BsonElement("ExercisePlan")]
        public List<ExercisePlanBase> ExercisePlans;
        [BsonElement("CalorieLogs")]
        public List<CalorieLog> CalorieLogs;
        [BsonElement("TotalCalories")]
        public int TotalCalories;
    }
}
