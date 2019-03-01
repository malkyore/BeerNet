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
    public class GoalController : Controller
    {
        HealthDataAccess accessor = new HealthDataAccess();

        // GET: api/Goal
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Goal> goals = accessor.GetAll<Goal>();
            return Json(goals.ToList());
        }

        // GET: api/Goal/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(string id)
        {
            Goal goals = accessor.Get<Goal>(id);
            return Json(goals);
        }

        [HttpGet("{month}/{day}/{year}")]
        [Authorize]
        public IActionResult Get(int month, int day, int year)
        {
            DateTime dateTime = new DateTime(year, month, day);
            IEnumerable<GoalItem> goals = accessor.GetCurrentGoalItems(dateTime);
            return Json(goals);
        }

        // POST: api/Goal
        [HttpPost]
        [HttpPost("{id}")]
        [Authorize]
        public Response Post(string id, [FromBody] Goal value)
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

        [HttpPost("ModifyGoalItem")]
        [Authorize]
        public Response Post([FromBody] GoalItemAction value)
        {
            int goalsCompleted = accessor.ModifyGoalItem(value);

            Response r = new Response();
            r.Success = goalsCompleted > 0;
            if (!r.Success)
                r.Message = "No GoalItems Completed";

            return r;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            return Json(accessor.Delete<Goal>(id));
        }
    }
}
