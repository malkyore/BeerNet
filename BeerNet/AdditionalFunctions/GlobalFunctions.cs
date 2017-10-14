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
            currentRecipe.recipeStats.og = ABVFunctions.basicOG(currentRecipe);
            currentRecipe.recipeStats.fg = ABVFunctions.basicFG(currentRecipe);
            currentRecipe.recipeStats.srm = ABVFunctions.basicSRM(currentRecipe);
            currentRecipe.recipeStats.abv = ABVFunctions.basicABV(currentRecipe);
            currentRecipe.recipeStats.ibu = IBU.basicIBU(currentRecipe);
            return currentRecipe.recipeStats;
        }
    }
}
