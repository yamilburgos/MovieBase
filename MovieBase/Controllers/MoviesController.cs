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
        public ActionResult Index() {
            List<Movie> movies = new List<Movie> {
                // Creates new movie instances to be loaded up.
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };

            // Calls Index.cshtml in Views/Movies for display with a list of movies.
            return View(movies);    
        }

        // Called when going to Movies/released/year/month
        public ActionResult ByReleaseDate(int year, int month) {
            // Displays a blank screen displaing year and month.
            return Content(year + "/" + month);
        }
    }
}