using BeerNet.Models;
using MongoDB.Bson;
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
            currentRecipe.recipeStats.initialStrikeWaterTemp = calcInitialStrikeWater(currentRecipe);
            currentRecipe.recipeStats.initialStrikeWaterVolume = calcInitialStrikeWaterVolume(currentRecipe);
            return currentRecipe.recipeStats;
        }

        private static double calcInitialStrikeWaterVolume(recipe currentRecipe)
        {
            double dGrainPounds = 0;
            foreach (fermentableAddition fa in currentRecipe.fermentables)
            {
                dGrainPounds += fa.weight;
            }

            return currentRecipe.recipeParameters.gristRatio * dGrainPounds;
        }

        private static double calcInitialStrikeWater(recipe currentRecipe)
        {
            double dGristRatio = currentRecipe.recipeParameters.gristRatio;
            double dInitialMashTemp = currentRecipe.recipeParameters.initialMashTemp;
            double dTargetMashTemp = currentRecipe.recipeParameters.targetMashTemp;

            return (.2 / dGristRatio) * (dTargetMashTemp - dInitialMashTemp) + dTargetMashTemp;
        }

        public static T AddIdIfNeeded<T>(T document, string id)
        {
            if (id != null)
            {
                var idProperty = typeof(T).GetProperty("Id");
                ObjectId value = (ObjectId)idProperty.GetValue(document);
                idProperty.SetValue(document, ObjectId.Parse(id));
            }

            return document;
        }
    }
}
