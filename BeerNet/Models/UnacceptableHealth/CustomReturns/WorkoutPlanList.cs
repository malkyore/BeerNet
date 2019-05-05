using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth.CustomReturns
{
    public class WorkoutPlanList
    {
        [BsonElement("WorkoutPlans")]
        public List<WorkoutPlan> WorkoutPlans;
    }
}
