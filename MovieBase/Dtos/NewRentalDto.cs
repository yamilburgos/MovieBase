using System;
using System.Collections.Generic;

namespace MovieBase.Dtos {

    public class NewRentalDto {
        // Properties used when presenting states.
        public int CustomerId { get; set; }

        // Data Annotations that adds properties to the database.
        public List<int> MovieIds { get; set; }
    }
}