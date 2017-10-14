using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BeerNet.Models;
using MongoDB.Bson;

namespace BeerNet.Controllers
{
    [Produces("application/json")]
    [Route("beernet/fermentable")]
    public class FermentableController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            DataAccess accessor = new DataAccess();
            IEnumerable<fermentable> currentRecipe = accessor.Getfermentables();
            return Json(currentRecipe.ToList<fermentable>());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            DataAccess accessor = new DataAccess();
            fermentable currentRecipe = accessor.Getfermentable(id);
            return Json(currentRecipe);
        }

        // POST api/values
        [HttpPost("{id}")]
        [HttpPost]
        public IActionResult Post([FromBody]fermentable value, string id)
        {
            //double ibu = MathFunctions.IBU.basicIBU(value, 1.07);

            DataAccess accessor = new DataAccess();
            if (id != null)
                value.Id = ObjectId.Parse(id);

            return Json(accessor.Postfermentable(value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {

            DataAccess accessor = new DataAccess();

            return Json(accessor.Deletefermentable(id));
        }
    }
}