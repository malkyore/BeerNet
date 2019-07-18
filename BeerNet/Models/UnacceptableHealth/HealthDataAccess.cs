using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.Models.UnacceptableHealth
{
    public class HealthDataAccess : DataAccess
    {
        public HealthDataAccess()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            _configuration = builder.Build();
            //mongodb://rest.unacceptable.beer:5283 <- the server IP and stuff
            _client = new MongoClient(_configuration.GetValue<string>("MongoLocation"));
            //_client = new MongoClient("mongodb://rest.unacceptable.beser:5283");
            _db = _client.GetDatabase("Health");
        }

        internal IEnumerable<Goal> GetAllGoalsSorted()
        {
            return _db.GetCollection<Goal>(typeof(Goal).Name).Find(_ => true).SortByDescending(x => x.StartDate).ToList();
        }

        //public IEnumerable<T> GetAll<T>(String sSort)
        //{
        //    //.SetSortOrder(SortBy.Ascending("SortByMe"))
        //    //return _db.GetCollection<T>(typeof(T).Name).Find(_ => true).SortBy(x => x[sSort]).ToList();
        //}

        public IEnumerable<DailyLog> GetAllDailyLogsSorted()
        {
            return _db.GetCollection<DailyLog>(typeof(DailyLog).Name).Find(_ => true).SortByDescending(x => x.date).ToList();
        }

        internal IEnumerable<GoalItem> GetCurrentGoalItems(DateTime dateTime)
        {
            dateTime = dateTime.AddHours(18);
            //IEnumerable<Goal> goals =_db.GetCollection<Goal>(typeof(Goal).Name).Find(x => x.StartDate <= dateTime && x.EndDate >= dateTime).ToList();
            IEnumerable<Goal> goals = _db.GetCollection<Goal>(typeof(Goal).Name).Find(x => dateTime >= x.StartDate && dateTime <= x.EndDate).ToList();
            List<GoalItem> goalItems = new List<GoalItem>();

            foreach (Goal g in goals)
            {
                foreach (GoalItem gi in g.GoalItems)
                {
                    if (gi.Date.Date == dateTime.Date)
                        goalItems.Add(gi);  
                }
            }

            return goalItems;
        }

        internal IEnumerable<Workout> GetAllWorkoutsByWorkoutPlanID(string id)
        {
            return _db.GetCollection<Workout>(typeof(Workout).Name).Find(x => x.WorkoutPlan.idString == id).SortByDescending(x => x.Date).ToList();
        }

        internal int ModifyGoalItem(GoalItemAction value)
        {
            int goalsUpdated = 0;

            IEnumerable<Goal> goals = _db.GetCollection<Goal>(typeof(Goal).Name).Find(x => x.StartDate <= value.Item.Date && x.EndDate >= value.Item.Date).ToList();
            foreach (Goal g in goals)
            {
                List<GoalItem> toRemove = new List<GoalItem>();

                foreach (GoalItem goalItem in g.GoalItems)
                {
                    if (goalItem.Date.Date == value.Item.Date.Date && goalItem.WorkoutType.name == value.Item.WorkoutType.name)
                    {
                        if (value.Remove)
                        {
                            //g.GoalItems.Remove(goalItem);
                            toRemove.Add(goalItem);
                            goalsUpdated++;
                        }
                        else
                        {
                            if (goalItem.Completed != value.Completed)
                            {
                                goalItem.Completed = value.Completed;
                                goalsUpdated++;
                            }
                            else if (goalItem.Date != value.Date)
                            {
                                goalItem.Date = value.Date;
                                //TODO: Move this to a history
                                goalsUpdated++;
                            }
                        }
                    }
                }

                foreach(GoalItem goalItem in toRemove)
                {
                    g.GoalItems.Remove(goalItem);
                }

                Post<Goal>(g);
            }

            return goalsUpdated;
        }

        internal DailyLog GetDailyLogByDate(DateTime date)
        {
            //date = date.AddHours(12); //the android app hardcodes it to noon to avoid timezone crap
            DateTime endDate = date.AddDays(1);

            try
            {
                //FilterDefinition<DailyLog> def = "{date: \"" + date.ToLongTimeString() + "\"}";
                var filter = Builders<DailyLog>.Filter.Eq("date", date);
                string collection = typeof(DailyLog).Name;
                List<DailyLog> result = _db.GetCollection<DailyLog>(collection).Find(filter).ToList<DailyLog>();
                result = _db.GetCollection<DailyLog>(collection).Find(x => x.date >= date && x.date <= endDate).ToList();
                if (result.Count > 0)
                    return result[0];
            }
            catch (Exception e)
            {

            }

            return default(DailyLog);
        }

        /*public List<WorkoutPlan> GetWorkoutPlansByExercise(string id) {
            result = _db.GetCollection<WorkoutPlan>("WorkoutPlan").Find()
        }*/


    }
}
