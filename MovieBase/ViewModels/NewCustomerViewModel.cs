using System.Collections.Generic;
using MovieBase.Models;

namespace MovieBase.ViewModels {

    public class NewCustomerViewModel {
        // Encapsulates all the data needed by the New
        // view & holds a reference to Customer.
        public List<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}