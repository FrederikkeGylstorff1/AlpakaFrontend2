using RestAlpakaMongo.Models;

using RestAlpakaMongo.GenericBase;
using RestAlpakaMongo.Interfaces;
using MongoDB.Driver;

namespace RestAlpakaMongo.Services
{
    public class LocationService : MongoDbService<Location>
    {
        public LocationService(IConfiguration config)
            : base(new MongoClient(config.GetConnectionString("DefaultConnection")), config, "Location")
        {

        }
    
    }
}
