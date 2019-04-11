using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerNet.MathFunctions;
using BeerNet.Models.UnacceptableHealth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerNet.Controllers.UnacceptableHealth
{
    [Route("health/[controller]")]
    [ApiController]
    public class MuscleController : Controller
    {
        HealthDataAccess accessor = new HealthDataAccess();

        // GET: api/Muscle
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            //IEnumerable<Goal> goals = accessor.GetAll<Goal>();
            IEnumerable<Muscle> goals = accessor.GetAll<Muscle>();
            return Json(goals.ToList());
        }

        // GET: api/Muscle/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Muscle goals = accessor.Get<Muscle>(id);
            return Json(goals);
        }

        // POST: api/Muscle
        [HttpPost]
        [HttpPost("{id}")]
        [Authorize]
        public Response Post(string id, [FromBody] Muscle value)
        {
            Response r = new Response();
            if (value == null)
            {
                r.Success = false;
                r.Message = "Null Muscle Found";
                return r;
            }

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
            return Json(accessor.Delete<Muscle>(id));
        }
    }
}
