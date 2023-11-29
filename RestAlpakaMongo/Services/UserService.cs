using RestAlpakaMongo.Models;

using RestAlpakaMongo.GenericBase;
using RestAlpakaMongo.Interfaces;
using MongoDB.Driver;

namespace RestAlpakaMongo.Services
{
    public class UserService : MongoDbService<Users>
    {
        public UserService(IConfiguration config)
            : base(new MongoClient(config.GetConnectionString("DefaultConnection")), config, "Users")
        {

        }
    
    }
}
