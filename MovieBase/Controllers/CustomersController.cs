using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MovieBase.Models;

namespace MovieBase.Controllers {
    public class CustomersController : Controller {

        // Called when going to Customers
        public ViewResult Index() {
            // Calls Index.cshtml in Views/Customers to display a list of customers.
            return View(GetCustomers());
        }

        // Called when going to Customers/Details/id
        public ActionResult Details(int id) {
            // Uses a query that returns a customer with a matching id (if possible).
            Customer customer = (from thisCustomer in GetCustomers() where
               thisCustomer.Id == id select thisCustomer).SingleOrDefault();
            // If this customer cannot be found, simply return this error page.
            if (customer == null) return HttpNotFound();
            // Calls Details.cshtml in Views/Customers to display a single customer.
            return View(customer);
        }

        private List<Customer> GetCustomers() {
            return new List<Customer> {
                // Creates new customer instances to be loaded up.
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}