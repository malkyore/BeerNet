using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeerNet.Models;
using MongoDB.Bson;

namespace BeerNet.Controllers
{
    [Route("beernet/[controller]")]
    public class hopController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            DataAccess accessor = new DataAccess();
            IEnumerable<hop> currentRecipe = accessor.GetHops();
            return Json(currentRecipe.ToList<hop>());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            DataAccess accessor = new DataAccess();
            hop currentRecipe = accessor.GetHop(id);
            return Json(currentRecipe);
        }

        // POST api/values
        [HttpPost("{id}")]
        [HttpPost]
        public IActionResult Post([FromBody]hop value, string id)
        {
            //double ibu = MathFunctions.IBU.basicIBU(value, 1.07);

            DataAccess accessor = new DataAccess();
            if (id != null)
                value.Id = ObjectId.Parse(id);
            
            return Json(accessor.PostHop(value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {

            DataAccess accessor = new DataAccess();

            return Json(accessor.DeleteHop(id));
        }
    }
}