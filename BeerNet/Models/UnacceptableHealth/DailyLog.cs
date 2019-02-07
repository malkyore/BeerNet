using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class DailyLog
    {
        public ObjectId Id { get; set; }
        public string idString
        {
            get
            {
                return Id.ToString();
            }
        }


        [BsonElement("date")]
        public DateTime date { get; set; }
        [BsonElement("usedflonase")]
        public bool usedFlonase { get; set; }
        [BsonElement("flonasereasoning")]
        public int flonaseReasoning { get; set; }
        [BsonElement("hadheadache")]
        public Boolean hadHeadache { get; set; }
        [BsonElement("workday")]
        public bool workDay { get; set; }
        [BsonElement("workrating")]
        public int workRating { get; set; }
        [BsonElement("personaldayrating")]
        public int personalDayRating { get; set; }
        [BsonElement("mindfulmoment")]
        public string mindfulMoment { get; set; }
        [BsonElement("overalnotes")]
        public string overalNotes { get; set; }
    }
}
