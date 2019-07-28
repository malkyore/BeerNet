using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BeerNet.Models;
using BeerNet.BeerXML.Models;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BeerNet.BeerXML
{
    public class BeerXMLHandler
    {
        private const double KGtoOZ = 35.71428571428571;

        public recipe ParseBeerXML(string xml)
        {
            //All the converted items
            RECIPE recipeFromXML = new RECIPE();
            List<fermentableObj> Fermentables = new List<fermentableObj>();
            List<hopObj> Hops = new List<hopObj>();
            List<yeastObj> Yeasts = new List<yeastObj>();
            List<miscObj> Miscs = new List<miscObj>();
            styleObj Style = new styleObj();

            //Load the string into an xml object
            XmlDocument xdoc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer((typeof(RECIPE)));
            xdoc.LoadXml(xml);

            //convert the xml object to json
            string json = JsonConvert.SerializeXmlNode(xdoc);
            JObject recipeInfoFromXML = JObject.Parse(json);

            // get the recipe info
            JToken results = recipeInfoFromXML["RECIPES"]["RECIPE"];
            recipeFromXML = results.ToObject<RECIPE>();

            //same with style
            results = recipeInfoFromXML["RECIPES"]["RECIPE"]["STYLE"];
            Style = results.ToObject<styleObj>();

            /*
             * When it converts xml to json, due to the way that Json uses list objects and XML does not
             * the parser can't tell the difference between a list and not a list...
             * 
             * So we come to this...
             * 
             * The try catches handle list vs not list.
             * 
             * For example
             * recipeInfoFromXML["RECIPES"]["RECIPE"]["FERMENTABLES"].Children().Children().Children()
             * 
             * retrieves items if they are encapsulated in a json list.
             * 
             * recipeInfoFromXML["RECIPES"]["RECIPE"]["FERMENTABLES"].Children().Children()
             * 
             * retrieves items if they are not encapsulated in a list.
             * 
             * So this should handle both instances because if you parse too deep it can't figure out what object you're
             * trying to map into and it throws an exception.
             * 
             * */
            try
            {
                IList<JToken> fermentablesList = recipeInfoFromXML["RECIPES"]["RECIPE"]["FERMENTABLES"].Children().Children().Children().ToList();
                foreach (JToken result in fermentablesList)
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    fermentableObj searchResult = result.ToObject<fermentableObj>();
                    Fermentables.Add(searchResult);
                }
            }
            catch (Exception e)
            {
                IList<JToken> fermentablesList = recipeInfoFromXML["RECIPES"]["RECIPE"]["FERMENTABLES"].Children().Children().ToList();
                foreach (JToken result in fermentablesList)
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    fermentableObj searchResult = result.ToObject<fermentableObj>();
                    Fermentables.Add(searchResult);
                }
            }

            try
            {
                IList<JToken> hopsList = recipeInfoFromXML["RECIPES"]["RECIPE"]["HOPS"].Children().Children().Children().ToList();
                foreach (JToken result in hopsList)
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    hopObj searchResult = result.ToObject<hopObj>();
                    Hops.Add(searchResult);
                }
            }
            catch (Exception e)
            {
                IList<JToken> hopsList = recipeInfoFromXML["RECIPES"]["RECIPE"]["HOPS"].Children().Children().ToList();
                foreach (JToken result in hopsList)
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    hopObj searchResult = result.ToObject<hopObj>();
                    Hops.Add(searchResult);
                }
            }


            try
            {
                IList<JToken> yeastList = recipeInfoFromXML["RECIPES"]["RECIPE"]["YEASTS"].Children().Children().Children().ToList();
                foreach (JToken result in yeastList)
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    yeastObj searchResult = result.ToObject<yeastObj>();
                    Yeasts.Add(searchResult);
                }
            }
            catch (Exception e)
            {
                IList<JToken> yeastList = recipeInfoFromXML["RECIPES"]["RECIPE"]["YEASTS"].Children().Children().ToList();
                foreach (JToken result in yeastList)
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    yeastObj searchResult = result.ToObject<yeastObj>();
                    Yeasts.Add(searchResult);
                }
            }

            try
            {
                IList<JToken> miscList = recipeInfoFromXML["RECIPES"]["RECIPE"]["MISCS"].Children().Children().Children().ToList();
                foreach (JToken result in miscList)
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    miscObj searchResult = result.ToObject<miscObj>();
                    Miscs.Add(searchResult);
                }
            }
            catch (Exception e)
            {
                IList<JToken> miscList = recipeInfoFromXML["RECIPES"]["RECIPE"]["MISCS"].Children().Children().ToList();
                foreach (JToken result in miscList)
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    miscObj searchResult = result.ToObject<miscObj>();
                    Miscs.Add(searchResult);
                }
            }

            recipe final = MapRecipeInfo(recipeFromXML, Fermentables, Hops, Yeasts, Miscs, Style);

            DataAccess accessor = new DataAccess();
            accessor.PostRecipe(final);

            return final;
        }

        public recipe MapRecipeInfo(RECIPE XMLRecipe, List<fermentableObj> Fermentables, List<hopObj> Hops, List<yeastObj> Yeasts, List<miscObj> Miscs, styleObj Style)
        {
            recipe beerNetRecipe = new recipe();
            beerNetRecipe.recipeParameters = new RecipeParameters();
            beerNetRecipe.fermentables = new List<fermentableAddition>();
            beerNetRecipe.hops = new List<hopAddition>();
            beerNetRecipe.adjuncts = new List<adjunctAddition>();
            beerNetRecipe.yeasts = new List<yeastAddition>();

           // beerNetRecipe.name = XMLRecipe.NAME;
           // beerNetRecipe.description = "Converted from Beer XML.";
           // beerNetRecipe.style = Style.NAME;
           // beerNetRecipe.recipeParameters.ibuCalcType = "basic";
           // beerNetRecipe.recipeParameters.fermentableCalcType = "basic";
           // beerNetRecipe.recipeParameters.ibuBoilTimeCurveFit = -0.04;
           // beerNetRecipe.recipeParameters.intoFermenterVolume = 5;
           // beerNetRecipe.hops = mapHopAdditions(Hops);
           // beerNetRecipe.fermentables = mapFermentableAdditions(Fermentables);
           // beerNetRecipe.yeasts = mapYeastAdditions(Yeasts);
           // beerNetRecipe.adjuncts = mapAdjuntAdditions(Miscs);
            return beerNetRecipe;
        }

        public List<hopAddition> mapHopAdditions(List<hopObj> Hops)
        {
            List<hopAddition> hopAdditions = new List<hopAddition>();

            foreach (hopObj h in Hops)
            {
                hop hp = new hop();
                hp.aau = h.ALPHA.Value;
                hp.name = h.NAME;

                hopAddition addition = new hopAddition();
                addition.time = (float)h.TIME.Value;
                addition.type = h.USE;
                addition.amount = (float)Math.Round(h.AMOUNT.Value * KGtoOZ, 2);//Amount is in kilograms
                addition.hop = hp;

                hopAdditions.Add(addition);
            }
            return hopAdditions;
        }

        public List<fermentableAddition> mapFermentableAdditions(List<fermentableObj> Fermentables)
        {
            List<fermentableAddition> fermentableAdditions = new List<fermentableAddition>();

            foreach (fermentableObj f in Fermentables)
            {
                fermentable fm = new fermentable();
                fm.name = f.NAME;
                //This might be wrong. http://howtobrew.com/book/section-2/what-is-malted-grain/extraction-and-maximum-yield
              //  fm.ppg = (float)(1000 * f.POTENTIAL.Value) - 1000;
                fm.type = f.TYPE;
                fm.color = (float)f.COLOR.Value;
                fm.maltster = f.ORIGIN;

                fermentableAddition addition = new fermentableAddition();
                addition.fermentable = fm;
               // addition.use = "Mash";
                addition.weight = (float)(f.AMOUNT * 2.2);//Amount is in kilograms
                fermentableAdditions.Add(addition);
            }
            return fermentableAdditions;
        }

        public List<yeast> mapYeastAdditions(List<yeastObj> Yeasts)
        {
            List<yeast> yeastAdditions = new List<yeast>();
            foreach (yeastObj y in Yeasts)
            {
                yeast ys = new yeast();
                ys.attenuation = (float)y.ATTENUATION;
                ys.lab = y.LABORATORY;
                ys.name = y.NAME;
                yeastAdditions.Add(ys);
            }
            return yeastAdditions;
        }
        public List<adjunctAddition> mapAdjuntAdditions(List<miscObj> Miscs)
        {
            List<adjunctAddition> adjunctAdditions = new List<adjunctAddition>();
            foreach (miscObj o in Miscs)
            {
                adjunct aj = new adjunct();
                aj.name = o.NAME;

                adjunctAddition adj = new adjunctAddition();
                adj.adjunct = aj;
                adj.amount = Math.Round(o.AMOUNT.Value * KGtoOZ, 2);//amount is in kg
                adj.unit = "oz";//thats what we're converting it to....
                adj.type = o.USE;
                adj.time = (float)o.TIME;//TIME is in minutes, I think that should be fine...
                adjunctAdditions.Add(adj);
            }
            return adjunctAdditions;
        }
    }
}
