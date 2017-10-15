using BeerNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.MathFunctions
{
    public static class ABVFunctions
    {
        public static double basicOG(recipe currentRecipe)
        {
            double IntoFermenterVolume = 0;
            double PPGCalc = 0;
            try
            {
                IntoFermenterVolume = currentRecipe.recipeParameters.intoFermenterVolume;
            }
            catch (Exception e)
            {
                IntoFermenterVolume = 5;

            }
            double og = 0;
            foreach (fermentableAddition f in currentRecipe.fermentables)
            {
                PPGCalc += f.fermentable.ppg * f.weight;
            }
            og = 1 + (PPGCalc / IntoFermenterVolume) / 1000;

            return og;
        }

        public static double basicFG(recipe currentRecipe)
        {
            int yeastCount = 0;
            double attenuationTotal = 0;
            double fg = 0;
            foreach (yeast y in currentRecipe.yeasts)
            {
                yeastCount += 1;
                attenuationTotal += y.attenuation;
            }

            double finalAttenuation = attenuationTotal / yeastCount;
            fg = 1 + (((currentRecipe.recipeStats.og - 1) * 1000) * ((100 - finalAttenuation) / 100)) / 1000;
            return fg;
        }

        public static double basicSRM(recipe currentRecipe)
        {
            double IntoFermenterVolume = 0;
            try
            {
                IntoFermenterVolume = currentRecipe.recipeParameters.intoFermenterVolume;
            }
            catch (Exception e)
            {
                IntoFermenterVolume = 5;
            }
                double srm = 0;
            foreach (fermentableAddition f in currentRecipe.fermentables)
            {
                srm += f.fermentable.color * f.weight;
            }
            srm = (float)(1.4922 * (Math.Pow(srm / IntoFermenterVolume, 0.69)));
            return srm;
        }

        public static double basicABV(recipe currentRecipe)
        {
            double abv = 0;
            abv = (float)((currentRecipe.recipeStats.og - currentRecipe.recipeStats.fg) * 131.25);
            if (abv > 10)
            {
                abv = (float)((76.08 * (currentRecipe.recipeStats.og - currentRecipe.recipeStats.fg) / (1.775 - currentRecipe.recipeStats.og)) * (currentRecipe.recipeStats.fg / 0.794));
            }
            return abv;
        }
    }
}
