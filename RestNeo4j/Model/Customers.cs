using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAlpaka.Model
{
    public class Customers
    {
        [Key]
        public int Customer_id { get; set; }

        [ForeignKey("User")]
        public int User_id { get; set; }

       
        public int Location_id { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name must be between 1 and 50 characters.")]
        public string First_name { get; set; }

  
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name must be between 1 and 50 characters.")]
        public string Last_name { get; set; }

      
        public string Phone_number { get; set; }

       
        public string Address { get; set; }

        // Navigation properties
        public Users User { get; set; }
        public Location Location { get; set; }
    }
}

