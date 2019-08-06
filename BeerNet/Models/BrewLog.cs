using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class BrewLog
    {
        public ObjectId Id { get; set; }
        public string idString
        {
            get
            {
                return Id.ToString();
            }
        }

        [BsonElement("recipeIdString")]
        public string recipeIdString;

        [BsonElement("name")]
        public String name;

        [BsonElement("originalRecipe")]
        public recipe originalRecipe;
        [BsonElement("rectifiedRecipe")]
        public recipe rectifiedRecipe;

        [BsonElement("mashStartTime")]
        public DateTimeOffset mashStartTime;
        [BsonElement("mashEndTime")]
        public DateTimeOffset mashEndTime;

        [BsonElement("vaurloff")]
        public Boolean vaurloff;

        [BsonElement("spargeStartTime")]
        public DateTimeOffset spargeStartTime;
        [BsonElement("spargeEndTime")]
        public DateTimeOffset spargeEndTime;

        [BsonElement("preBoilVolumeEstimate")]
        public string preBoilVolumeEstimate; //"up to the rivets"
        [BsonElement("preBoilVolumeActual")]
        public double preBoilVolumeActual;

        [BsonElement("boilStartTime")]
        public DateTimeOffset boilStartTime;
        [BsonElement("boilEndTime")]
        public DateTimeOffset boilEndTime;

        [BsonElement("actualHopAdditions")]
        public BrewlogIngredientAddition actualHopAdditions;
        [BsonElement("actualAdjunctAdditions")]
        public BrewlogIngredientAddition actualAdjunctAdditions;

        [BsonElement("og")]
        public double og;
        [BsonElement("fg")]
        public double fg;

        [BsonElement("actualBatchSizeString")]
        public string actualBatchSizeString; //"2 cases", "2 cases and 3 bottles", what we actually got
        [BsonElement("actualBatchSize")]
        public double actualBatchSize; //in gallons

        [BsonElement("lastModifiedGuid")]
        public Guid lastModifiedGuid;
    }
}
