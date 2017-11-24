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
        }
    }
}