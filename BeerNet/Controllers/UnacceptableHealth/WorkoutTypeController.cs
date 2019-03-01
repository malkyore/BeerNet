using System;
using System.Collections.Generic;
using System.Linq;
using BeerNet.MathFunctions;
using BeerNet.Models.UnacceptableHealth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeerNet.Controllers.UnacceptableHealth
{
    [Route("health/[controller]")]
    [ApiController]
    public class WorkoutTypeController : Controller
    {
        HealthDataAccess accessor = new HealthDataAccess();

        // GET: api/WorkoutType
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            IEnumerable<WorkoutType> workoutTypes = accessor.GetAll<WorkoutType>();
            return Json(workoutTypes.ToList());
        }

        // GET: api/WorkoutType/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(string id)
        {
            WorkoutType workoutType = accessor.Get<WorkoutType>(id);


            return Json(workoutType);
        }

        // POST: api/WorkoutType
        [HttpPost]
        [HttpPost("{id}")]
        [Authorize]
        public Response Post(string id, [FromBody] WorkoutType value)
        {
            Response r = new Response();
            if (value == null)
            {
                r.Success = false;
                r.Message = "Null WorkoutType Found";
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
            return Json(accessor.Delete<WorkoutType>(id));
        }
    }
}
