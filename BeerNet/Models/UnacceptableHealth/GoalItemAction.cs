using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class GoalItemAction
    {
        [BsonElement("Item")]
        public GoalItem Item;
        [BsonElement("Completed")]
        public Boolean Completed;
        [BsonElement("Date")]
        public DateTime Date;
        [BsonElement("Remove")]
        public Boolean Remove;
    }
}
