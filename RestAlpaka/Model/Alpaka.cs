using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RestAlpaka.Model
{
    public class Alpaka
    {
        [Key]
        public int alpaka { get; set; }

        [Required(ErrorMessage = "The color field is required.")]
        public string color { get; set; }

       
        
        [Required(ErrorMessage = "The Alpaka_name field is required.")]
        public string Alpaka_name { get; set; }

        [Required(ErrorMessage = "The description field is required.")]
        public string description { get; set; }

        public byte[]? ImageData { get; set; }

      



    }
}
