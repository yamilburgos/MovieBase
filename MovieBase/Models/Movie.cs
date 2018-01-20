using System;
using System.ComponentModel.DataAnnotations;

namespace MovieBase.Models {

    public class Movie {
        // Properties used when presenting states.
        public int Id { get; set; }

        // Data Annotations that adds properties to the database.

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }
    }
}