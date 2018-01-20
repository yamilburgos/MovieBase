using System;
using System.Data.Entity;
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

        // Called when going to Movies/New
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New() {
            // A query that returns all movie genres (Id and Name).
            List<Genre> genres = _context.Genres.ToList();
            
            MovieFormViewModel viewModel = new MovieFormViewModel {
                // Creates a new movie for the view at this time.
                Movie = new Movie(),
                // A query to contain all genres available via a list.
                Genres = genres
            };

            // Specifies MovieForm's View page to visit. Also passes viewModel data.
            return View("MovieForm", viewModel);
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
            // A query that returns database movie with matching ids (if possible).
            Movie movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            // Checks to see if this customer exists. If not, return error page.
            if (movie == null) return HttpNotFound();

            MovieFormViewModel viewModel = new MovieFormViewModel {
                // Takes the result given from the above query to use for the view.
                Movie = movie,
                // A query to contain all genres available via a list.
                Genres = _context.Genres.ToList()
            };

            // Specifies MovieForm's View page to visit. Also passes viewModel data.
            return View("MovieForm", viewModel);
        }

        // Posts an action when going to Movies/Save
        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie) {
            // Changes the flow of the program by using validation
            // data. Still return the same view if it isn't valid.
            if (!ModelState.IsValid) {
                MovieFormViewModel viewModel = new MovieFormViewModel {
                    // Takes the result given from the above query to use for the view.
                    Movie = movie,
                    // A query to contain all genres available via a list.
                    Genres = _context.Genres.ToList()
                };

                // Still return MovieForm's View page to visit. Also passes viewModel data.
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0) {
                // Done for new movies who yet to have an id.
                // Added to the dbContext memory, not the database!
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }

            else {
                // First query the database to find the movie with this existing id.
                Movie movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                // Then pass along the movie's new information to this chosen variant.
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            // This will save the changes to the database.
            _context.SaveChanges();
            // Redirects the user back to the list of movies (to Index).
            return RedirectToAction("Index", "Movies");
        }

        // Called when going to Movies
        public ActionResult Index() {
            // Checks the user's role with AspNewUserRoles. Then display
            // a list of movies with different menu options available.
            if (User.IsInRole(RoleName.CanManageMovies)) return View("List");
            else return View("ReadOnlyList");
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