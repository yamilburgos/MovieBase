using System.Collections.Generic;
using System.Web.Mvc;
using MovieBase.Models;
using MovieBase.ViewModels;

namespace MovieBase.Controllers {
    public class MoviesController : Controller {

        // Called when going to Movies/Random
        public ActionResult Random() {
            // Creating a new instance of movie with a given name.
            Movie movie = new Movie() { Name = "Shrek!" };

            List<Customer> customers = new List<Customer> {
                // Creates new customer instances to be loaded up.
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"},
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
        public ActionResult Index(int pageIndex = 1, string sortBy = "Name") {
            // Checks to see if this string was set to null or only white space.
            sortBy = string.IsNullOrWhiteSpace(sortBy) ? "Name" : sortBy;
            // Return a blank screen displaying the following information provided.
            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        // Called when going to Movies/released/year/month
        public ActionResult ByReleaseDate(int year, int month) {
            // Displays a blank screen displaing year and month.
            return Content(year + "/" + month);
        }
    }
}