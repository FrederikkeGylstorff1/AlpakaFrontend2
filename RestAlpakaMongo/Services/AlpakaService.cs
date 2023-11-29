using MongoDB.Driver;
using RestAlpakaMongo.GenericBase;
using RestAlpakaMongo.Interfaces;
using RestAlpakaMongo.Models;

namespace RestAlpakaMongo.Services;

public class AlpakaService : MongoDbService<Alpaka>
{
    public AlpakaService(IConfiguration config)
        : base(new MongoClient(config.GetConnectionString("DefaultConnection")), config, "Alpakas")
    {

    }

    // Implement other CRUD operations here
}