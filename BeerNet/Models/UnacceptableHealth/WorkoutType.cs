using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class WorkoutType : WorkoutTypeBase
    {
        public ObjectId Id { get; set; }
        public string idString
        {
            get
            {
                return Id.ToString();
            }
        }

    }
}
