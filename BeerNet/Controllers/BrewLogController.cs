using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerNet.MathFunctions;
using BeerNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerNet.Controllers
{
    [Route("beernet/[controller]")]
    [ApiController]
    public class BrewLogController : Controller
    {
        DataAccess accessor = new DataAccess();

        // GET: api/BrewLog
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            IEnumerable<BrewLog> brewLogs = accessor.GetAll<BrewLog>();
            return Json(brewLogs);
        }

        // GET: api/BrewLog/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(string id)
        {
            BrewLog brew = accessor.Get<BrewLog>(id);
            return Json(brew);
        }

        // POST: api/BrewLog
        [HttpPost]
        [HttpPost("{id}")]
        [Authorize]
        public LastModifiedGuidResponse Post([FromBody] BrewLog value, string id)
        {
            LastModifiedGuidResponse response = new LastModifiedGuidResponse();

            if (value != null)
            {
                try
                {
                    /*
                     * Checks if someone else has modified the recipe.
                     * */
                    if (!String.IsNullOrEmpty(id))
                    {
                        BrewLog existingRecipe = accessor.Get<BrewLog>(id);
                        if (existingRecipe.lastModifiedGuid != value.lastModifiedGuid)
                        {
                            throw new Exception("Recipe has been modified.  Please refresh");
                        }
                    }
                    Guid lastModified = Guid.NewGuid();
                    value.lastModifiedGuid = lastModified;
                    value = GlobalFunctions.AddIdIfNeeded(value, id);

                    accessor.Post<BrewLog>(value);
                    
                    response.lastModifiedGuid = lastModified;
                    response.idString = value.idString;
                    return response;
                }
                catch (Exception e)
                {
                    response.Fail(e);
                    return response;
                }
            } else
            {
                response.Message = "No BrewLog given.";
                response.Success = false;
            }

            return response;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
        }

        [HttpGet("recipe/{id}")]
        [Authorize]
        public IActionResult getForRecipe(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                IEnumerable<BrewLog> brewLogs = accessor.GetBrewLogsForRecipe(id);
                return Json(brewLogs);
            }

            Response r = new Response();
            r.Success = false;
            r.Message = "No ID provided.";
            return Json(r);
        }
    }
}
