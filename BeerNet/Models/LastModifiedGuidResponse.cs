using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models
{
    public class LastModifiedGuidResponse : Response
    {
        public Guid lastModifiedGuid;
        public string idString;
    }
}
