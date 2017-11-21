using BeerNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet
{
    public class RecipeStatsResponse : Response
    {
        public RecipeStatistics recipeStats;

        public string idString;

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
