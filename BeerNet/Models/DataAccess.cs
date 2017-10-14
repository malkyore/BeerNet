using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using BeerNet.Models;

namespace BeerNet.Models
{
    public class DataAccess
    {
        MongoClient _client;
        //MongoServer _server;
        IMongoDatabase _db;

        public DataAccess()
        {
            //mongodb://rest.unacceptable.beer:5283 <- the server IP and stuff
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("BeerNet");
        }

        public IEnumerable<hop> GetHops()
        {
            return _db.GetCollection<hop>("hop").Find(_ => true).ToList();
        }

        public hop GetHop(string id)
        {
            FilterDefinition<hop> def = "{id: " + id + "}";
            ObjectId hopObjectID = ObjectId.Parse(id);
            hopObjectID.ToString();
            return _db.GetCollection<hop>("hop").Find(j => j.Id == hopObjectID).ToList<hop>()[0];
        }

        public IEnumerable<recipe> GetRecipes()
        {
            return _db.GetCollection<recipe>("recipe").Find(_ => true).ToList();
        }

        public recipe GetRecipe(string id)
        {
            FilterDefinition<recipe> def = "{id: " + id + "}";
            ObjectId recipeObjectID = ObjectId.Parse(id);
            recipeObjectID.ToString();
            return _db.GetCollection<recipe>("recipe").Find(j => j.Id == recipeObjectID).ToList<recipe>()[0];
        }

        public string PostRecipe(recipe currentRecipe)
        {
            if (currentRecipe.Id == ObjectId.Empty)
            {
                _db.GetCollection<recipe>("recipe").InsertOne(currentRecipe);
                return currentRecipe.Id.ToString();
            }
            else
            {
                ObjectId recipeObjectID = ObjectId.Parse(currentRecipe.idString);
                currentRecipe.Id = recipeObjectID;
                _db.GetCollection<recipe>("recipe").ReplaceOne<recipe>(j => j.Id == recipeObjectID, currentRecipe);
                return currentRecipe.Id.ToString();
            }
        }

        public string deleteRecipe(string id)
        {
            try
            {
                _db.GetCollection<recipe>("recipe").DeleteOne<recipe>(j => j.Id == ObjectId.Parse(id));
                return "success";
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }

        public Response PostHop(hop h)
        {
            Response r = new Response();
            try
            {
                if (h.Id == ObjectId.Empty)
                {
                    _db.GetCollection<hop>("hop").InsertOne(h);
                }
                else
                {
                    _db.GetCollection<hop>("hop").ReplaceOne(j => j.Id == h.Id, h);
                }

                r.Message = h.Id.ToString();
            } catch (Exception ex)
            {
                r.Fail(ex);
                
            }

            return r;
        }

        public Response DeleteHop(string id)
        {
            Response r = new Response();
            try
            {
                _db.GetCollection<hop>("hop").DeleteOne(j => j.Id == ObjectId.Parse(id));
            } catch (Exception ex)
            {
                r.Fail(ex);
            }

            return r;
        }


    }
}
