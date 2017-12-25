using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using MovieBase.Models;

namespace MovieBase.Controllers.API {
    public class CustomersController : ApiController {
        // Used to access the database for this class.
        private ApplicationDbContext _context;

        public CustomersController() {
            // Initialized upon calling this controller during run-time.
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<Customer> GetCustomers() {
            // Returns a list of objects (customers).
            return _context.Customers.ToList();
        }

        // GET /api/customers/1
        public Customer GetCustomer(int id) {
            // Returns one object (customer) by using a matching id.
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            // If there's no customer, return the standard not found http response.
            if (customer == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            // Otherwise return the customer:
            return customer;
        }

        // POST /api/customers
        [HttpPost] public Customer CreateCustomer(Customer customer) {
            // Changes the program's flow via using validation data or return an error.
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            // Adds it to dbContext before saving it to the database. Finally return customer.
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        // PUT /api/customers/1
        [HttpPut] public void UpdateCustomer(int id, Customer customer) {
            // Changes the program's flow via using validation data or return an error.
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            // Returns one object (customer) by using a matching id.
            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            // If there's no customer, return the standard not found http response.
            if (customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            // Passover values from customer to the database's variants.
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribed = customer.IsSubscribed;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            // Saves the changes to the database.
            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete] public void DeleteCustomer(int id) {
            // Returns one object (customer) by using a matching id.
            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            // If there's no customer, return the standard not found http response.
            if (customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            // Delete the customer & saves the changes to the database.
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}