using System.Web.Mvc;

namespace MovieBase.Controllers {
    public class RentalsController : Controller {
        // Called when going to Movies/New
        public ActionResult New() {
            return View();
        }
    }
}