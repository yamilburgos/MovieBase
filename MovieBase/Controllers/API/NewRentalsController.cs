using System;
using System.Web.Http;
using MovieBase.Dtos;
using MovieBase.Models;

namespace MovieBase.Controllers.API {
    public class NewRentalsController : ApiController {

        [HttpPost]
        // Creates a new object for movies when called.
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental) {
            throw new NotImplementedException();
        }
    }
}