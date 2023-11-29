using RestAlpakaMongo.GenericBase;
using System.ComponentModel.DataAnnotations;

namespace RestAlpakaMongo.Models
{
    public class Payments : BaseEntity
    {
 
        public int Payment_id { get; set; }
        public int Booking_id { get; set; }
        public DateTime Payment_date { get; set; }
        public decimal Amount { get; set; }
    }
}
