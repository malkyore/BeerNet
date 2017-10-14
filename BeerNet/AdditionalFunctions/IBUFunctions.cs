using BeerNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet.MathFunctions
{
    public static class IBU
    {
        public static double basicIBU(recipe currentRecipe)
        {
            List<hopAddition> value = currentRecipe.hops;
            double fG = 0;
            double fT = 0;
            double Util = 0;
            double ibu = 0;
            double IBUBoilTimeCurveFit = -0.04;
            double IntoFermenterVolume = 5;
            foreach (hopAddition h in value)
            {
                if (h.type == "Boil")
                {
                    fG = (1.65 * (Math.Pow(0.000125, (currentRecipe.recipeStats.og - 1))));
                    fT = ((1 - Math.Pow(Math.E, IBUBoilTimeCurveFit * h.time)) / 4.15);
                    Util = fG * fT;
                    ibu += (((h.amount * h.hop.aau) * Util * 74.89) / IntoFermenterVolume);
                }
            }

            return ibu;
        }
    }
}
