﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAlpaka.Model
{
    public class Reviews
    {
        [Key]
        public int Review_id { get; set; }

        [ForeignKey("Customers")]
        public int Customer_id { get; set; }

        [ForeignKey("Alpaka")]
        public int Alpaka_id { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        public string Comment { get; set; }

        [DataType(DataType.Date)]
        public DateTime Review_date { get; set; }

        // Navigation properties
        public Customers Customer { get; set; }
        public Alpaka Alpaka { get; set; }
    }

   

   

}

