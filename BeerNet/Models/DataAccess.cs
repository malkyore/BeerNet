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
            _client = new MongoClient("mongodb://localhost:27017");
            //_server = _client.Get
            _db = _client.GetDatabase("BeerNet");
        }

        public IEnumerable<hop> GetHops()
        {
            return _db.GetCollection<hop>("hop").Find(_ => true).ToList();
        }

        public hop GetHop(string id)
        {
            //var res = Query<hop>.EQ(p => p.Id, id);
            FilterDefinition<hop> def = "{id: " + id + "}";
            ObjectId hopObjectID = ObjectId.Parse(id);
            hopObjectID.ToString();
            return _db.GetCollection<hop>("hop").Find(j => j.Id == hopObjectID).ToList<hop>()[0];
            //dsfasdf
        }

        public IEnumerable<recipe> GetRecipes()
        {
            return _db.GetCollection<recipe>("recipe").Find(_ => true).ToList();
        }

        public recipe GetRecipe(string id)
        {
            //var res = Query<hop>.EQ(p => p.Id, id);
            FilterDefinition<recipe> def = "{id: " + id + "}";
            ObjectId recipeObjectID = ObjectId.Parse(id);
            recipeObjectID.ToString();
            return _db.GetCollection<recipe>("recipe").Find(j => j.Id == recipeObjectID).ToList<recipe>()[0];
            //dsfasdf
        }

    }
}
