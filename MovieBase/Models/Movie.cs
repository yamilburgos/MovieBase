using System;
using System.ComponentModel.DataAnnotations;

namespace MovieBase.Models {

    public class Movie {
        // Properties used when presenting states.
        public int Id { get; set; }
        // Data Annotations that adds properties to the database.
        [Required] public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")] [Required]
        public byte GenreId { get; set; }

        [Required] [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required] public DateTime DateAdded { get; set; }

        [Required] [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }
    }
}