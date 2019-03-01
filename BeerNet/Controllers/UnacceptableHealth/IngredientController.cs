using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerNet.MathFunctions;
using BeerNet.Models;
using BeerNet.Models.UnacceptableHealth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerNet.Controllers.UnacceptableHealth
{
    [Route("health/[controller]")]
    [ApiController]
    public class IngredientController : Controller
    {
        HealthDataAccess accessor = new HealthDataAccess();
        // GET: api/Ingredient
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            IEnumerable<Ingredient> currentRecipe = accessor.GetAll<Ingredient>();
            return Json(currentRecipe.ToList());
        }

        // GET: api/Ingredient/5
        [HttpGet("{id}", Name = "Get")]
        [Authorize]
        public IActionResult Get(string id)
        {
            Ingredient currentRecipe = accessor.Get<Ingredient>(id);
            return Json(currentRecipe);
        }

        // POST: api/Ingredient
        /*[HttpPost]
        public void Post([FromBody] string value)
        {

        }*/

        // PUT: api/Ingredient/5
        [HttpPost("{id}")]
        [HttpPost]
        [Authorize]
        public IActionResult Post(string id, [FromBody] Ingredient value)
        {
            value = GlobalFunctions.AddIdIfNeeded(value, id);

            return Json(accessor.Post(value));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            return Json(accessor.Delete<Ingredient>(id));
        }
    }
}
