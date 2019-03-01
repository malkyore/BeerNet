using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class Goal
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
        public string name { get; set; }
        [BsonElement("StartDate")]
        [BsonDateTimeOptions]
        public DateTime StartDate;
        [BsonElement("EndDate")]
        [BsonDateTimeOptions]
        public DateTime EndDate;
        [BsonElement("Description")]
        public String Description;
        [BsonElement("GoalItems")]
        public List<GoalItem> GoalItems;
        [BsonElement("PendingGoalItems")]
        public List<PendingGoalItem> PendingGoalItems;
        [BsonElement("BasedOnWeek")]
        public Boolean BasedOnWeek;
        [BsonElement("OverallGoalAmount")]
        public decimal OverallGoalAmount;
        [BsonElement("OverallGoalAmountType")]
        public WorkoutTypeBase OverallGoalAmountType;
        [BsonElement("Acheived")]
        public Boolean Acheived;
    }
}
