using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerNet.MathFunctions;
using BeerNet.Models.UnacceptableHealth;
using BeerNet.Models.UnacceptableHealth.CustomReturns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace BeerNet.Controllers.UnacceptableHealth
{
    [Route("health/[controller]")]
    [ApiController]
    public class WorkoutPlanController : Controller
    {
        HealthDataAccess accessor = new HealthDataAccess();

        // GET: api/WorkoutPlan
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            IEnumerable<WorkoutPlan> goals = accessor.GetAll<WorkoutPlan>();
            return Json(goals.ToList());
        }

        // GET: api/WorkoutPlan/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Response r = new Response();
            
            WorkoutPlan plan = accessor.Get<WorkoutPlan>(id);
    
            if (plan == null || plan == default(WorkoutPlan))
            {
                r.Success = false;
                r.Message = "Null or default plan loaded";
            } else
            {
                r.Success = true;
                r.Message = JsonConvert.SerializeObject(plan);
            }

            return Json(r);
        }

        // GET: api/WorkoutPlan/WithExtras/5
        [HttpGet("WithExtras/{id}")]
        [HttpGet("WithExtras")]
        [Authorize]
        public IActionResult GetWithExtras(string id)
        {
            Response r = new Response();
            WorkoutPlanWithExtras data = new WorkoutPlanWithExtras();
            WorkoutPlan workoutPlan;
            List<Exercise> exercises = accessor.GetAll<Exercise>().ToList();
            List<WorkoutType> workoutTypes = accessor.GetAll<WorkoutType>().ToList();

            try
            {
                if (String.IsNullOrEmpty(id))
                {
                    workoutPlan = null;
                }
                else
                {
                    workoutPlan = accessor.Get<WorkoutPlan>(id);
                }

                data.WorkoutPlan = workoutPlan;
                data.Exercises = exercises;
                data.WorkoutTypes = workoutTypes;

                r.Success = true;
                r.Message = JsonConvert.SerializeObject(data);
            } catch (Exception ex)
            {
                r.Success = false;
                r.Message = ex.Message;
            }

            return Json(r);
        }

        // GET: api/workoutPlanByExercise/idString
        [HttpGet("ByExercise/{id}")]
        [Authorize]
        public IActionResult getByExercise(string id) {
            Response r = new Response();
            
            try {
                WorkoutPlanList workoutList = new WorkoutPlanList();
                IEnumerable<WorkoutPlan> allPlans = accessor.GetAll<WorkoutPlan>();
                List<WorkoutPlan> result = new List<WorkoutPlan>(); //accessor.GetWorkoutPlansByExercise(id);

                int c = 0;

                foreach (WorkoutPlan wp in allPlans) {
                    foreach (ExercisePlanBase ep in wp.ExercisePlans) {
                        c++;
                        if (String.Compare(id, ep.Exercise.idString) == 0) {
                            result.Add(wp);
                            //break;
                        }
                    }
                }

                workoutList.WorkoutPlans = result;

                r.Success = true;
                r.Message = JsonConvert.SerializeObject(workoutList);
            } catch (Exception ex) {
                r.Success = false;
                r.Message = ex.Message;
            }

            return Json(r);
        }

        // POST: api/WorkoutPlan
        [HttpPost]
        [HttpPost("{id}")]
        [Authorize]
        public Response Post(string id, [FromBody] WorkoutPlan value)
        {
            Response r = new Response();
            if (value == null)
            {
                r.Success = false;
                r.Message = "Null WorkoutPlan Found";
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
            return Json(accessor.Delete<WorkoutPlan>(id));
        }
    }
}
