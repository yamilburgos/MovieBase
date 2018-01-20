using System;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using MovieBase.Dtos;
using MovieBase.Models;

namespace MovieBase.Controllers.API {
    public class NewRentalsController : ApiController {
        // Used to access the database for this class.
        private ApplicationDbContext _context;

        public NewRentalsController() {
            // Initialized upon calling this controller during run-time.
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        // Creates a new object for movies when called.
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental) {
            // Obtain a single customer based on their ids (if they exist).
            Customer customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);
            // Obtain a list of movies based on the Customer's selection.
            List<Movie> movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (Movie movie in movies) {
                // Checks to see if the Movie's availability is sufficient enough.
                if (movie.NumberAvailable <= 0) return BadRequest("Movie is not available.");
                // Decrease the amount available due to it being rented out.
                movie.NumberAvailable--;

                // For every movie, create a new rental with the following info.
                Rental rental = new Rental {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                // Then add each rental to the database to be saved.
                _context.Rentals.Add(rental);
            }

            // Save changes to database and return a positive http result.
            _context.SaveChanges();
            return Ok();
        }
    }
}