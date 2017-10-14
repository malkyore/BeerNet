using BeerNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.MathFunctions
{
    public static class GlobalFunctions
    {
        public static RecipeStatistics updateStats(recipe currentRecipe)
        {
            //Add OG Calc here
            //Add SRM Calc here
            //Add ABV Calc here
            currentRecipe.recipeStats.ibu = IBU.basicIBU(currentRecipe);

            return currentRecipe.recipeStats;
        }
    }
}
