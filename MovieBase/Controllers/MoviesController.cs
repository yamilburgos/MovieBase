using System.Web.Mvc;
using MovieBase.Models;

namespace MovieBase.Controllers {
    public class MoviesController : Controller {

        // Called when going to Movies/Random
        public ActionResult Random() {
            // Creating a new instance of movie with a given name.
            Movie movie = new Movie() { Name = "Shrek!" };
            // Calls Random.cshtml in Views/Movies for display.
            return View(movie);
            /// Alternative way to return a view result.
            /// return new ViewResult();
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
    }
}