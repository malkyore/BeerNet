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

        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("date")]
        public DateTime date { get; set; }
        [BsonElement("HealthRating")]
        public int HealthRating { get; set; }
        [BsonElement("BBD")]
        public bool BBD { get; set; }
        [BsonElement("UsedFlonase")]
        public bool UsedFlonase { get; set; }
        [BsonElement("FlonaseReasoning")]
        public int FlonaseReasoning { get; set; }
        [BsonElement("HadHeadache")]
        public Boolean HadHeadache { get; set; }
        [BsonElement("WorkDay")]
        public bool WorkDay { get; set; }
        [BsonElement("WorkRating")]
        public int WorkRating { get; set; }
        [BsonElement("PersonalDayRating")]
        public int PersonalDayRating { get; set; }
        [BsonElement("MindfulMoment")]
        public string MindfulMoment { get; set; }
        [BsonElement("OverallNotes")]
        public string OverallNotes { get; set; }
    }
}
