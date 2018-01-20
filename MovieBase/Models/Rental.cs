using System;
using System.ComponentModel.DataAnnotations;

namespace MovieBase.Models {

    public class Rental {
        // Properties used when presenting states.
        public int Id { get; set; }

        // Data Annotations that adds properties to the database.

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }

        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}