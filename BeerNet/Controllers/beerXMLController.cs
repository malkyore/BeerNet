using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BeerNet.Models;
using MongoDB.Bson;
using BeerNet.MathFunctions;
using Microsoft.AspNetCore.Authorization;
using BeerNet.BeerXML;

namespace BeerNet.Controllers
{
    [Route("beernet/[controller]")]
    public class beerXMLController : Controller
    {
        // POST api/values
        //[HttpPost("{id}")]
        [HttpPost]
        [Authorize]
        public recipe Post(string beerXml)
        {
            BeerXMLHandler handler = new BeerXMLHandler();
            
            recipe convertedRecipe = handler.ParseBeerXML(beerXml.ToString());

            return convertedRecipe;
        }
    }
}