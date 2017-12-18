using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MovieBase.Models;
using MovieBase.ViewModels;

namespace MovieBase.Controllers {
    public class CustomersController : Controller {
        // Used to access the database for this class.
        private ApplicationDbContext _context;

        public CustomersController() {
            // Initialized upon calling this controller during run-time.
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            // Created in order to properly dispose this object.
            _context.Dispose();
        }

        // Called when going to Customers/New
        public ActionResult New() {
            CustomerFormViewModel viewModel = new CustomerFormViewModel {
                // Creates a new customer for the view at this time.
                Customer = new Customer(),
                // A query to contain all membership types available via a list.
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            // Specifies CustomerForm's View page to visit. Also passes viewModel data.
            return View("CustomerForm", viewModel);
        }

        // Posts an action when going to Customers/Save
        [HttpPost] public ActionResult Save(Customer customer) {

            // Changes the flow of the program by using validation
            // data. Still return the same view if it isn't valid.
            if (!ModelState.IsValid) {
                CustomerFormViewModel viewModel = new CustomerFormViewModel {
                    // Takes the result given from the above query to use for the view.
                    Customer = customer,
                    // A query to contain all membership types available via a list.
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                // Still return CustomerForm's View page to visit. Also passes viewModel data.
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0) {
                // Done for new customers who yet to have an id.
                // Added to the dbContext memory, not the database!
                _context.Customers.Add(customer);
            }

            else {
                // First query the database to find the customer with this existing id.
                Customer customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                // Then pass along the customer's new information to this chosen variant.
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribed = customer.IsSubscribed;
            }

            // This will save the changes to the database.
            _context.SaveChanges();
            // Redirects the user back to the list of customers (to Index).
            return RedirectToAction("Index", "Customers");
        }

        // Called when going to Customers
        public ViewResult Index() {
            // Calls Index.cshtml in Views/Customers to display a list of customers.
            // Gets all customers from the database. A DBSet that has been defined.
            // ToList() helps executes the query for this property. Include() will
            // also past the MembershipType property to view as well.
            return View(_context.Customers.Include(c => c.MembershipType).ToList());
        }

        // Called when going to Customers/Details/id
        public ActionResult Details(int id) {
            // A query that returns database customer with matching ids (if possible).
            // Include() will also past the MembershipType property to view as well.
            Customer customer = _context.Customers.Include(c => c.MembershipType).
                SingleOrDefault(c => c.Id == id);

            // If this customer cannot be found, simply return this error page.
            if (customer == null) return HttpNotFound();
            // Calls Details.cshtml in Views/Customers to display a single customer.
            return View(customer);
        }

        public ActionResult Edit(int id) {
            // A query that returns database customer with matching ids (if possible).
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            // Checks to see if this customer exists. If not, return error page.
            if (customer == null) return HttpNotFound();

            CustomerFormViewModel viewModel = new CustomerFormViewModel {
                // Takes the result given from the above query to use for the view.
                Customer = customer,
                // A query to contain all membership types available via a list.
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            // Specifies CustomerForm's View page to visit. Also passes viewModel data.
            return View("CustomerForm", viewModel);
        }
    }
}