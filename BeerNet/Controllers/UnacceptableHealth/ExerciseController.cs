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
    public class ExerciseController : Controller
    {
        HealthDataAccess accessor = new HealthDataAccess();

        // GET: api/Exercise
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            //IEnumerable<Goal> goals = accessor.GetAll<Goal>();
            IEnumerable<Exercise> goals = accessor.GetAll<Exercise>();
            return Json(goals.ToList());
        }

        // GET: api/Exercise/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(string id)
        {
            Exercise goals = accessor.Get<Exercise>(id);
            return Json(goals);
        }


        /*[HttpGet("withMuscles/")]
        public IActionResult GetWithMuscles()
        {
            return GetWithMuscles("");
        }*/

        [HttpGet("withMuscles/{id}")]
        [HttpGet("withMuscles/")]
        [Authorize]
        public IActionResult GetWithMuscles(string id)
        {
            Exercise exercise = accessor.Get<Exercise>(id);
            IEnumerable<Muscle> muscles = accessor.GetAll<Muscle>();

            Response r = new Response();

            if (exercise != null || muscles != null)
            {
                r.Success = true;
                /*ExerciseWithMuscleList result = new ExerciseWithMuscleList();
                result.Exercise = exercise;
                result.Muscles = muscles;
                r.Message = JsonConvert.SerializeObject(result);*/

                var result = (Exercise: exercise, Muscles: muscles);

                //r.Message = JsonConvert.SerializeObject(new { exercise, muscles });
                r.Message = JsonConvert.SerializeObject(new { result.Exercise, result.Muscles });
            } else
            {
                string sError = "";
                if (exercise == null) sError += "Exercise is null";
                if (muscles == null)
                {
                    if (sError.Length > 0) sError += " & ";
                    sError += "Muscles is null";
                }

                if (sError.Length == 0) sError = "Unknown Error";
                r.Success = false;
                r.Message = sError;
            }

            return Json(r);
        }

        // POST: api/Muscle
        [HttpPost]
        [HttpPost("{id}")]
        [Authorize]
        public Response Post(string id, [FromBody] Exercise value)
        {
            Response r = new Response();
            if (value == null)
            {
                r.Success = false;
                r.Message = "Null Exercise Found";
                return r;
            }

            /*if (id != null)
            {
                Exercise exercise = accessor.Get<Exercise>(id);
                if (!exercise.Description.Equals(value.Description))
                {
                    bUpdateDescriptions = true;
                }
            }*/

            value = GlobalFunctions.AddIdIfNeeded(value, id);
            r = accessor.Post(value);
            if (r.Success)
            {
                r.Message = value.idString;
                CopySettingsToAllWorkoutPlans(value);
            }
            return r;
        }

        private void CopySettingsToAllWorkoutPlans(Exercise exercise)
        {
            //TODO: Maybe make this an actual query instead of loading every single workout plan...
            //TODO: db.WorkoutPlan.update({"ExercisePlan.Exercise.idString": "5cae9cc627ba9d2ab8569e01"}, {$set : {"ExercisePlan.$.Exercise.Description" : "test"}})
            IEnumerable<WorkoutPlan> workoutPlans = accessor.GetAll<WorkoutPlan>();
            foreach (WorkoutPlan wp in workoutPlans)
            {
                foreach (ExercisePlanBase ep in wp.ExercisePlans)
                {
                    if (ep.Exercise.idString.Equals(exercise.idString))
                    {
                        ep.Exercise.ShowTime = exercise.ShowTime;
                        ep.Exercise.ShowWeight = exercise.ShowWeight;
                        ep.Exercise.ShowReps = exercise.ShowReps;
                        ep.Exercise.Description = exercise.Description;
                        ep.Exercise.name = exercise.name;
                    }
                }

                accessor.Post(wp);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            return Json(accessor.Delete<Exercise>(id));
        }
    }
}
