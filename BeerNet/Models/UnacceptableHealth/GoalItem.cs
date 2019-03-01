using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class GoalItem
    {
        /*public ObjectId Id { get; set; }
        public string idString
        {
            get
            {
                return Id.ToString();
            }
        }*/

        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("WorkoutType")]
        public WorkoutTypeBase WorkoutType;
        [BsonElement("Date")]
        [BsonDateTimeOptions]
        public DateTime Date;
        [BsonElement("Completed")]
        public bool Completed;
    }
}
