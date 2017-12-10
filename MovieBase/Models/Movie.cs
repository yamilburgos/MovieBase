using System;
using System.ComponentModel.DataAnnotations;

namespace MovieBase.Models {

    public class Movie {
        // Properties used when presenting states.
        public int Id { get; set; }
        // Data Annotations that adds properties to the database.
        [Required] public string Name { get; set; }
        [Required] public string Genre { get; set; }
        [Required] public DateTime ReleaseDate { get; set; }
        [Required] public DateTime DateAdded { get; set; }
        [Required] public int NumberInStock { get; set; }
    }
}