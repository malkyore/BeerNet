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
    public class DailyLogController : Controller
    {
        // GET: api/DailyLog
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            DataAccess accessor = new DataAccess();
            IEnumerable<DailyLog> currentRecipe = accessor.GetAll<DailyLog>();
            return Json(currentRecipe.ToList());
        }


        // GET: api/DailyLog/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(string id)
        {
            DataAccess accessor = new DataAccess();
            DailyLog currentRecipe = accessor.Get<DailyLog>(id);
            return Json(currentRecipe);
        }

        // POST: api/DailyLog
        [HttpPost]
        [HttpPost("{id}")]
        [Authorize]
        public Response Post(string id, [FromBody] DailyLog value)
        {
            Response r = new Response();
            if (value == null)
            {
                r.Success = false;
                r.Message = "Null DailyLog Found";
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

            return Json(accessor.Delete<DailyLog>(id));
        }
    }
}
