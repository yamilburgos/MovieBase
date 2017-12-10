using System;

namespace MovieBase.Models {

    public class MembershipType {
        // Properties used when presenting membership.
        // Using these datatypes as values are very small.
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}