﻿using System;
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
    public class DailyLogController : Controller
    {
        HealthDataAccess accessor = new HealthDataAccess();
        // GET: api/DailyLog
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            IEnumerable<DailyLog> currentRecipe = accessor.GetAllDailyLogsSorted();
                //accessor.GetAll<DailyLog>();
            return Json(currentRecipe.ToList());
        }


        // GET: api/DailyLog/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(string id)
        {
            DailyLog currentRecipe = accessor.Get<DailyLog>(id);


            return Json(currentRecipe);
        }

        [HttpGet("{month}/{day}/{year}")]
        [Authorize]
        public IActionResult Get(int month, int day, int year)
        {
            DateTime date = new DateTime(year, month, day);
            DailyLog dailyLog = accessor.GetDailyLogByDate(date);
            if (dailyLog == null)
            {
                Response r = new Response();
                r.Success = true;
                r.Message = "Log does not exist.";

                return Json(r);
            }
            return Json(dailyLog);
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
            return Json(accessor.Delete<DailyLog>(id));
        }
    }
}
