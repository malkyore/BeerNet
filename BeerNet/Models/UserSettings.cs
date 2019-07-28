using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class userSettings : userSettingsBase
    {
        public ObjectId Id { get; set; }
        public new string idString
          {
              get
              {
                  return Id.ToString();
              }
          }

    }
}
