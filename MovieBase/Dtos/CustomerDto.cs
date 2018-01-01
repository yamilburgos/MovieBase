using System;
using System.ComponentModel.DataAnnotations;

namespace MovieBase.Dtos {

    public class CustomerDto {
        // Properties used when presenting states.
        public int Id { get; set; }

        // Data Annotations that adds properties to the database.

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }

        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }
    }
}