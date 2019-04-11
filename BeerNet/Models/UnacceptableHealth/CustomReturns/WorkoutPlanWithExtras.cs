using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth.CustomReturns
{
    //I'm not sure if this is a great name so I might want to try to come up with something better
    public class WorkoutPlanWithExtras
    {
        [BsonElement("WorkoutPlan")]
        public WorkoutPlanBase WorkoutPlan;
        [BsonElement("Exercises")]
        public List<Exercise> Exercises;
        [BsonElement("WorkoutTypes")]
        public List<WorkoutType> WorkoutTypes;
    }
}
