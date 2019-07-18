using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerNet.MathFunctions;
using BeerNet.Models.UnacceptableHealth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BeerNet.Controllers.UnacceptableHealth
{
    [Route("health/[controller]")]
    [ApiController]
    public class WorkoutController : Controller
    {
        HealthDataAccess accessor = new HealthDataAccess();

        // GET: api/Workout
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            //IEnumerable<Goal> goals = accessor.GetAll<Goal>();
            IEnumerable<Workout> goals = accessor.GetAll<Workout>();
            return Json(goals.ToList());
        }

        // GET: api/Workout/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(string id)
        {
            Workout goals = accessor.Get<Workout>(id);
            return Json(goals);
        }

        // POST: api/Workout
        [HttpPost]
        [HttpPost("{id}")]
        [Authorize]
        public Response Post(string id, [FromBody] Workout value)
        {
            Response r = new Response();
            if (value == null)
            {
                r.Success = false;
                r.Message = "Null Workout Found";
                return r;
            }

            value = GlobalFunctions.AddIdIfNeeded(value, id);
            r = accessor.Post(value);
            if (r.Success)
            {
                r.Message = value.idString;
            }
            return r;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            return Json(accessor.Delete<Workout>(id));
        }

        [HttpGet("gethistory/{id}")]
        [Authorize]
        public Response GetHistory(string id)
        {
            Response r = new Response();
            if (id == null)
            {
                r.Success = false;
                r.Message = "Null ID Passed";
                return r;
            }

            IEnumerable<Workout> workouts = accessor.GetAllWorkoutsByWorkoutPlanID(id);

            r.Success = true;
            r.Message = JsonConvert.SerializeObject(workouts);

            return r;
        }
    }
}
