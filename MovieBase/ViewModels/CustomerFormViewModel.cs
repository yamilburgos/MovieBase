using System.Collections.Generic;
using MovieBase.Models;

namespace MovieBase.ViewModels {

    public class CustomerFormViewModel {
        // Encapsulates all the data needed by the CustomerForm
        // view & holds a reference to Customer.
        public List<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}