using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestAlpakaMongo.GenericBase;

namespace RestAlpakaMongo.Models
{
    public class Booking : BaseEntity
    {
    
     
        public DateTime Booking_date { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }

        // Navigation properties
        public Customers Customer { get; set; }
        public Alpaka Alpaka { get; set; }
    }
}
