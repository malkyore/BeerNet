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
        // GET: api/Ingredient
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            DataAccess accessor = new DataAccess();
            IEnumerable<Ingredient> currentRecipe = accessor.GetAll<Ingredient>();
            return Json(currentRecipe.ToList());
        }

        // GET: api/Ingredient/5
        [HttpGet("{id}", Name = "Get")]
        [Authorize]
        public IActionResult Get(string id)
        {
            DataAccess accessor = new DataAccess();
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
            DataAccess accessor = new DataAccess();
            value = GlobalFunctions.AddIdIfNeeded(value, id);

            return Json(accessor.Post(value));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            DataAccess accessor = new DataAccess();

            return Json(accessor.Delete<Ingredient>(id));
        }
    }
}
