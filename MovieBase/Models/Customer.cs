using System;
using System.ComponentModel.DataAnnotations;

namespace MovieBase.Models {

    public class Customer {
        // Properties used when presenting states.
        public int Id { get; set; }
        // Data Annotations that adds properties to the database.
        [Required] [StringLength(255)] public string Name { get; set; }
        public bool IsSubscribed { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
    }
}