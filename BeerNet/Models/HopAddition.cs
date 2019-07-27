﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class hopAddition
    {
        [BsonElement("additionGuid")]
        public string additionGuid { get; set; }
        [BsonElement("amount")]
        public float amount { get; set; }
        [BsonElement("type")]
        public string type { get; set; }
        [BsonElement("time")]
        public float time { get; set; }
        [BsonElement("hop")]
        public hopbase hop { get; set; }
    }
}
