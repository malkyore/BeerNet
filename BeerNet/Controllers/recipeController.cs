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
using Newtonsoft.Json;

namespace BeerNet.Controllers
{
    [Route("beernet/[controller]")]
    public class recipeController : Controller
    {
        // GET api/values
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            DataAccess accessor = new DataAccess();
            IEnumerable<recipe> currentRecipe = accessor.GetAll<recipe>();
            return Json(currentRecipe.ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(string id)
        {
            DataAccess accessor = new DataAccess();
            recipe currentRecipe = accessor.Get<recipe>(id);
            return Json(currentRecipe);
        }

        // POST api/values
        [HttpPost("{id}")]
        [HttpPost]
        [Authorize]
        public RecipeStatsResponse Post([FromBody]recipe value, string id)
        {
            RecipeStatsResponse response = new RecipeStatsResponse();
            if (value != null)
            {
                DataAccess accessor = new DataAccess();
                try
                {

                    value = GlobalFunctions.AddIdIfNeeded(value, id);
                    value.recipeStats = MathFunctions.GlobalFunctions.updateStats(value);
                    bool recipeResponse = accessor.PostRecipe(value);
                    response = new RecipeStatsResponse();
                    response.recipeStats = value.recipeStats;
                    response.idString = value.idString;
                    return response;
                }
                catch (Exception e)
                {
                    response.Fail(e);
                    return response;
                }
            }
            else
            {
                response.RecipeNullFailure();
                return response;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(string id)
        {
            DataAccess accessor = new DataAccess();
            return Json(accessor.Delete<recipe>(id));
        }

        [HttpGet("getWithIngredients/{id}")]
        [Authorize]
        public Response GetWithIngredients(string id)
        {
            DataAccess da = new DataAccess();

            Response r = new Response();

            try
            {
                recipe recipe = da.Get<recipe>(id);
                IEnumerable<hop> hops = da.GetAll<hop>();
                IEnumerable<fermentable> fermentables = da.GetAll<fermentable>();
                IEnumerable<yeast> yeasts = da.GetAll<yeast>();

                if (recipe == null || hops == null || fermentables == null || yeasts == null)
                {
                    throw new Exception("Some data returned null");
                }

                r.Success = true;
                var data = (Recipe: recipe, Hops: hops, Fermentables: fermentables, Yeasts: yeasts);

                r.Message = JsonConvert.SerializeObject(new { data.Recipe, data.Hops, data.Fermentables, data.Yeasts});

            } catch (Exception ex)
            {
                r.Fail(ex);
            }

            return r;
        }
    }
}