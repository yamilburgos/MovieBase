using System.Collections.Generic;
using MovieBase.Models;

namespace MovieBase.ViewModels {

    public class RandomMovieViewModel {
        // Properties used when presenting random movies.
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}