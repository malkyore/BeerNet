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


        public recipe GetHop(string id)
        {
            //var res = Query<hop>.EQ(p => p.Id, id);
            FilterDefinition<recipe> def = "{id: " + id + "}";
            ObjectId jsdfjfdjf = ObjectId.Parse(id);
            jsdfjfdjf.ToString();
            return _db.GetCollection<recipe>("recipe").Find(j => j.Id == jsdfjfdjf).ToList<recipe>()[0];
        }

        //public Product Create(Product p)
        //{
        //    _db.GetCollection<Product>("Products").Save(p);
        //    return p;
        //}
        //
        //public void Update(ObjectId id, Product p)
        //{
        //    p.Id = id;
        //    var res = Query<Product>.EQ(pd => pd.Id, id);
        //    var operation = Update<Product>.Replace(p);
        //    _db.GetCollection<Product>("Products").Update(res, operation);
        //}
        //public void Remove(ObjectId id)
        //{
        //    var res = Query<Product>.EQ(e => e.Id, id);
        //    var operation = _db.GetCollection<Product>("Products").Remove(res);
        //}
    }
}
