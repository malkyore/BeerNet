using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

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

        internal IEnumerable<yeast> GetYeasts()
        {
            return _db.GetCollection<yeast>("yeast").Find(_ => true).ToList();
        }

        public IEnumerable<hop> GetHops()
        {
            return _db.GetCollection<hop>("hop").Find(_ => true).ToList();
        }

        internal yeast GetYeast(string id)
        {
            FilterDefinition<hop> def = "{id: " + id + "}";
            ObjectId yeastObjectID = ObjectId.Parse(id);
            yeastObjectID.ToString();
            List<yeast> result = _db.GetCollection<yeast>("yeast").Find(j => j.Id == yeastObjectID).ToList<yeast>();
            if (result.Count > 0)
                return result[0];
            return null;
        }

        internal IEnumerable<fermentable> Getfermentables()
        {
            return _db.GetCollection<fermentable>("fermentable").Find(_ => true).ToList();
        }

        internal fermentable Getfermentable(string id)
        {
            FilterDefinition<hop> def = "{id: " + id + "}";
            ObjectId fermentableObjectID = ObjectId.Parse(id);
            fermentableObjectID.ToString();
            List<fermentable> result = _db.GetCollection<fermentable>("fermentable").Find(j => j.Id == fermentableObjectID).ToList<fermentable>();
            if (result.Count > 0)
                return result[0];
            return null;
        }

        internal IEnumerable<adjunct> Getadjuncts()
        {
            return _db.GetCollection<adjunct>("adjunct").Find(_ => true).ToList();
        }

        internal adjunct Getadjunct(string id)
        {
            FilterDefinition<hop> def = "{id: " + id + "}";
            ObjectId adjunctObjectID = ObjectId.Parse(id);
            adjunctObjectID.ToString();
            List<adjunct> result = _db.GetCollection<adjunct>("adjunct").Find(j => j.Id == adjunctObjectID).ToList<adjunct>();
            if (result.Count > 0)
                return result[0];
            return null;
        }

        public hop GetHop(string id)
        {
            FilterDefinition<hop> def = "{id: " + id + "}";
            ObjectId hopObjectID = ObjectId.Parse(id);
            hopObjectID.ToString();
            List<hop> result = _db.GetCollection<hop>("hop").Find(j => j.Id == hopObjectID).ToList<hop>();
            if (result.Count > 0)
                return result[0];
            return null;
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

        public bool PostRecipe(recipe currentRecipe)
        {
            if (currentRecipe.Id == ObjectId.Empty)
            {
                _db.GetCollection<recipe>("recipe").InsertOne(currentRecipe);
                return true;
            }
            else
            {
                ObjectId recipeObjectID = ObjectId.Parse(currentRecipe.idString);
                currentRecipe.Id = recipeObjectID;
                _db.GetCollection<recipe>("recipe").ReplaceOne<recipe>(j => j.Id == recipeObjectID, currentRecipe);
                return true;
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

        internal object PostYeast(yeast value)
        {
            Response r = new Response();
            try
            {
                if (value.Id == ObjectId.Empty)
                {
                    _db.GetCollection<yeast>("yeast").InsertOne(value);
                }
                else
                {
                    _db.GetCollection<yeast>("yeast").ReplaceOne(j => j.Id == value.Id, value);
                }

                r.Message = value.Id.ToString();
            }
            catch (Exception ex)
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
            }
            catch (Exception ex)
            {
                r.Fail(ex);
            }

            return r;
        }

        public Response DeleteYeast(string id)
        {
            Response r = new Response();
            try
            {
                _db.GetCollection<yeast>("yeast").DeleteOne(j => j.Id == ObjectId.Parse(id));
            } catch (Exception ex)
            {
                r.Fail(ex);
            }

            return r;
        }

        internal object Postfermentable(fermentable value)
        {
            Response r = new Response();
            try
            {
                if (value.Id == ObjectId.Empty)
                {
                    _db.GetCollection<fermentable>("fermentable").InsertOne(value);
                }
                else
                {
                    _db.GetCollection<fermentable>("fermentable").ReplaceOne(j => j.Id == value.Id, value);
                }

                r.Message = value.Id.ToString();
            }
            catch (Exception ex)
            {
                r.Fail(ex);

            }

            return r;
        }

        public Response Deletefermentable(string id)
        {
            Response r = new Response();
            try
            {
                _db.GetCollection<fermentable>("fermentable").DeleteOne(j => j.Id == ObjectId.Parse(id));
            }
            catch (Exception ex)
            {
                r.Fail(ex);
            }

            return r;
        }

        internal object Postadjunct(adjunct value)
        {
            Response r = new Response();
            try
            {
                if (value.Id == ObjectId.Empty)
                {
                    _db.GetCollection<adjunct>("adjunct").InsertOne(value);
                }
                else
                {
                    _db.GetCollection<adjunct>("adjunct").ReplaceOne(j => j.Id == value.Id, value);
                }

                r.Message = value.Id.ToString();
            }
            catch (Exception ex)
            {
                r.Fail(ex);

            }

            return r;
        }

        public Response Deleteadjunct(string id)
        {
            Response r = new Response();
            try
            {
                _db.GetCollection<adjunct>("adjunct").DeleteOne(j => j.Id == ObjectId.Parse(id));
            }
            catch (Exception ex)
            {
                r.Fail(ex);
            }

            return r;
        }


    }
}
