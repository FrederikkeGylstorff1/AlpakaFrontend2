using MongoDB.Driver;
using RestAlpakaMongo.GenericBase;
using RestAlpakaMongo.Interfaces;
using RestAlpakaMongo.Models;

namespace RestAlpakaMongo.Services;

public class AlpakaService : MongoDbService<Alpaka>
{
    public AlpakaService(IMongoClient client, IConfiguration config)
        : base(client, config, "Alpakas")
    {
    }
    // Implement other CRUD operations here
}