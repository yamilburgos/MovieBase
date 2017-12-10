using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MovieBase.Models;

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

        // Called when going to Customers
        public ViewResult Index() {
            // Calls Index.cshtml in Views/Customers to display a list of customers.
            // Gets all customers from the database. A DBSet that has been defined.
            // ToList() helps executes the query for this property. Include() will
            // also past the MembershipType object/property to view as well.
            return View(_context.Customers.Include(c => c.MembershipType).ToList());
        }

        // Called when going to Customers/Details/id
        public ActionResult Details(int id) {
            // A query that returns database customer(s) with matching ids (if possible).
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            // If this customer cannot be found, simply return this error page.
            if (customer == null) return HttpNotFound();
            // Calls Details.cshtml in Views/Customers to display a single customer.
            return View(customer);
        }
    }
}