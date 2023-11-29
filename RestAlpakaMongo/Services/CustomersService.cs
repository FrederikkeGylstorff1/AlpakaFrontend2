using RestAlpakaMongo.Models;
using RestAlpakaMongo.GenericBase;
using RestAlpakaMongo.Interfaces;
using MongoDB.Driver;

namespace RestAlpakaMongo.Services;

    public class CustomersService : MongoDbService<Customers>
    {
        public CustomersService(IConfiguration config)
            : base(new MongoClient(config.GetConnectionString("DefaultConnection")), config, "Customers")
        {

        }
    
    }

