using System;
using System.ComponentModel.DataAnnotations;

namespace MovieBase.Models {

    public class Min18YearsIfMember : ValidationAttribute {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            // Obtains access to customers for validation purposes.
            Customer customer = (Customer)validationContext.ObjectInstance;

            // Checks the selected membership type for early validation.
            if (customer.MembershipTypeId == (byte)MembershipType.Membership.None ||
                customer.MembershipTypeId == (byte)MembershipType.Membership.PayAsYouGo)
                return ValidationResult.Success;
            
            // Checks for any dates provided before going further.
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");
            
            // Calculates the customer's age with today's (current) date.
            int age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            // Then validate age before returning the proper validation result.
            return (age >= 18) ? ValidationResult.Success 
                : new ValidationResult("Must be 18 years old.");
        }
    }
}