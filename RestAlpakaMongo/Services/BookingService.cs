using MongoDB.Driver;
using RestAlpakaMongo.GenericBase;
using RestAlpakaMongo.Interfaces;
using RestAlpakaMongo.Models;

namespace RestAlpakaMongo.Services;


public class BookingService : MongoDbService<Booking>
{
    public BookingService(IConfiguration config)
           : base(new MongoClient(config.GetConnectionString("DefaultConnection")), config, "Booking")
          {

          }


}
        
    

