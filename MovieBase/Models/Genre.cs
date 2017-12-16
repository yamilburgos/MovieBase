using System;
using System.ComponentModel.DataAnnotations;

namespace MovieBase.Models {

    public class Genre {
        // Properties used when presenting membership.
        public byte Id { get; set; }
        [Required] [StringLength(255)] public string Name { get; set; }
    }
}