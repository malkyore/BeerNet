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
    public class FoodRecipeController : Controller
    {
        // GET: api/FoodRecipe
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            DataAccess accessor = new DataAccess();
            IEnumerable<FoodRecipe> currentRecipe = accessor.GetAll<FoodRecipe>();
            return Json(currentRecipe.ToList());
        }
        

        // GET: api/FoodRecipe/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(string id)
        {
            DataAccess accessor = new DataAccess();
            FoodRecipe currentRecipe = accessor.Get<FoodRecipe>(id);
            return Json(currentRecipe);
        }

        // POST: api/FoodRecipe
        [HttpPost]
        [HttpPost("{id}")]
        public Response Post(string id, [FromBody] FoodRecipe value)
        {
            Response r = new Response();
            if (value == null)
            {
                r.Success = false;
                r.Message = "Null Recipe Found";
                return r;
            }

            DataAccess accessor = new DataAccess();
            value = GlobalFunctions.AddIdIfNeeded(value, id);
            accessor.Post(value);

            r.Message = value.idString;

            return r;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            DataAccess accessor = new DataAccess();

            return Json(accessor.Delete<FoodRecipe>(id));
        }
    }
}
