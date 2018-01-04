using System;
using System.ComponentModel.DataAnnotations;

namespace MovieBase.Dtos {

    public class MovieDto {
        // Properties used when presenting states.
        public int? Id { get; set; }

        // Data Annotations that adds properties to the database.

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}