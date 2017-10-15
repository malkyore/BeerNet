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
            //Add OG Calc here
            //Add SRM Calc here
            //Add ABV Calc here
            currentRecipe.recipeStats.ibu = IBU.basicIBU(currentRecipe);

            return currentRecipe.recipeStats;
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
