using System.ComponentModel.DataAnnotations;

namespace MovieBase.Models {

    public class MembershipType {
        // Properties used when presenting membership.
        // Using these datatypes as values are very small.
        public byte Id { get; set; }
        [Required] public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public enum Membership : byte {
            // Enum fields to help identify membership types.
            None = 0,
            PayAsYouGo = 1,
            Monthly = 2,
            Quarterly = 3,
            Yearly = 4
        }
    }
}