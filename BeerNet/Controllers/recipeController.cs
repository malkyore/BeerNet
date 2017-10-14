using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BeerNet.Models;

namespace BeerNet.Controllers
{
    [Route("beernet/[controller]")]
    public class recipeController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            DataAccess accessor = new DataAccess();
            IEnumerable<recipe> currentRecipe = accessor.GetRecipes();
            return Json(currentRecipe.ToList<recipe>());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            DataAccess accessor = new DataAccess();
            recipe currentRecipe = accessor.GetRecipe(id);
            return Json(currentRecipe);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]recipe value)
        {
            //double ibu = MathFunctions.IBU.basicIBU(value, 1.07);
            return "Not Implemented";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}