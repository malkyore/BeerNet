using BeerNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet
{
    public class RecipeStatsResponse : Response
    {

        public bool Success;
        public string Message;
        public RecipeStatistics recipeStats;

        public RecipeStatsResponse()
        {
            Success = true;
            Message = "";
        }

        public void RecipeNullFailure()
        {
            Success = false;
            Message = "Recipe was not found";
            recipeStats = null;
        }
    }
}
