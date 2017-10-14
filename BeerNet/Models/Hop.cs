using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BeerNet.Models
{
    public class hop : hopbase
    {

        public ObjectId Id {get;set;}
        public new string idString
        {
            get
            {
                return Id.ToString();
            }
        }
    }
}
