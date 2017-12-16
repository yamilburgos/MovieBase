using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using MovieBase.Models;
using MovieBase.ViewModels;

namespace MovieBase.Controllers {
    public class MoviesController : Controller {
        // Used to access the database for this class.
        private ApplicationDbContext _context;

        public MoviesController() {
            // Initialized upon calling this controller during run-time.
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            // Created in order to properly dispose this object.
            _context.Dispose();
        }

        // Called when going to Movies/Random
        public ActionResult Random() {
            // Creating a new instance of movie with a given name.
            Movie movie = new Movie() { Name = "Shrek!" };

            List<Customer> customers = new List<Customer> {
                // Creates new customer instances to be loaded up.
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" },
            };

            RandomMovieViewModel viewModel = new RandomMovieViewModel {
                // Holds info about a movie and its customers to be displayed.
                Movie = movie,
                Customers = customers
            };

            // Calls Random.cshtml in Views/Movies for display.
            return View(viewModel);
        }

        // Called when going to Movies/Edit/id
        public ActionResult Edit(int id) {
            // Displays a blank screen displaing id= and a number.
            return Content("id=" + id);
        }

        // Called when going to Movies
        public ActionResult Index() {
            // Calls Index.cshtml in Views/Movies to display a list of movies. Gets
            // all movies from the database. A DBSet that has been defined. ToList()
            // helps executes the query for this property.
            return View(_context.Movies.ToList());
        }

        // Called when going to Movies/Details/id
        public ActionResult Details(int id) {
            // A query that returns database movies(s) with matching ids (if possible).
            Movie movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            // If this movie cannot be found, simply return this error page.
            if (movie == null) return HttpNotFound();
            // Calls Details.cshtml in Views/Movies to display a single movie.
            return View(movie);
        }

        // Called when going to Movies/released/year/month
        public ActionResult ByReleaseDate(int year, int month) {
            // Displays a blank screen displaing year and month.
            return Content(year + "/" + month);
        }
    }
}