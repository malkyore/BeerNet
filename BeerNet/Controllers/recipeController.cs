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
        [HttpPost("{id}/{bSaveRecipe}")]
        [Authorize]
        public RecipeStatsResponse Post([FromBody]recipe value, string id, Boolean bSaveRecipe)
        {
            RecipeStatsResponse response = new RecipeStatsResponse();
            if (value != null)
            {
                DataAccess accessor = new DataAccess();
                try
                {
                    /*
                     * Checks if someone else has modified the recipe.
                     * */
                    if (!String.IsNullOrEmpty(id) && !id.Equals("000000000000000000000000"))
                    {
                        recipe existingRecipe = accessor.Get<recipe>(id);
                        //TODO: id is coming in as all 0's and then existing recipe becomes null, then this throws an exception
                        if (existingRecipe.lastModifiedGuid != value.lastModifiedGuid)
                        {
                            throw new Exception("Recipe has been modified.  Please refresh");
                        }
                    }
                    Guid lastModified = Guid.NewGuid();
                    value.lastModifiedGuid = lastModified;
                    value = GlobalFunctions.AddIdIfNeeded(value, id);
                    value.recipeStats = MathFunctions.GlobalFunctions.updateStats(value);

                    if (bSaveRecipe)
                    {
                        accessor.PostRecipe(value);
                    }

                    response = new RecipeStatsResponse();
                    response.recipeStats = value.recipeStats;
                    response.idString = value.idString;
                    response.lastModifiedGuid = lastModified;
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

        // POST api/values
        [HttpPost("{id}")]
        [HttpPost]
        [Authorize]
        public RecipeStatsResponse Post([FromBody]recipe value, string id)
        {
            return Post(value, id, true);
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
                IEnumerable<style> styles = da.GetAll<style>();

                if (recipe == null || hops == null || fermentables == null || yeasts == null)
                {
                    throw new Exception("Some data returned null");
                }

                r.Success = true;
                var data = (Recipe: recipe, Hops: hops, Fermentables: fermentables, Yeasts: yeasts, Styles: styles);

                r.Message = JsonConvert.SerializeObject(new { data.Recipe, data.Hops, data.Fermentables, data.Yeasts, data.Styles});

            } catch (Exception ex)
            {
                r.Fail(ex);
            }

            return r;
        }

        [HttpPost("mashInfusion/{T1}/{T2}/{Wm}/{Tw}")]
        [Authorize]
        public Response MashInfusion([FromBody]recipe recipe, double T1, double T2, double Wm, double Tw)
        {
            Response r = new Response();
            try
            {
                DataAccess accessor = new DataAccess();
                

                double Wa = 0; //Wa = water to add to the mash (the result of the equation
                               //double T1 = 0; //T1 = Initial(Current) temp of mash
                               //double T2 = 0; //T2 = Target temp of mash
                double G = recipe.grainsInPounds(); //G = pounds of grains in mash
                                                   //double Wm = 0; //Wm = total amount of water in mash
                                                   //double Tw = 0; //Tw = temperature of water you're adding to mash


                Wa = (T2 - T1) * (.2 * G + Wm) / (Tw - T2);

                r.Success = true;
                r.Message = Wa.ToString();
            } catch (Exception ex)
            {
                r.Fail(ex);
            }

            return r;
        }

        //needs to be a POST because android doesn't send body's with GET
        /*[HttpPost("calculateStats")]
        [HttpPost("calculateStats/{checkLastModifiedGuid}")]
        [Authorize]
        public RecipeStatsResponse CalculateStats([FromBody]recipe value, Boolean checkLastModifiedGuid)
        {
            RecipeStatsResponse response = new RecipeStatsResponse();
            
            try
            {
                if (checkLastModifiedGuid)
                {
                    DataAccess dataAccess = new DataAccess();
                    recipe r = dataAccess.Get<recipe>(value.idString);
                    if (r.lastModifiedGuid != value.lastModifiedGuid)
                        throw new Exception("Recipe has been modified.  Please refresh");
                }

                response.recipeStats = GlobalFunctions.updateStats(value);
            } catch (Exception ex)
            {
                response.Fail(ex);
            }

            return response;

            
        }*/
    }
}