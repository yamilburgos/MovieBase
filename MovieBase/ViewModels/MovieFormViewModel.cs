using System.Collections.Generic;
using MovieBase.Models;

namespace MovieBase.ViewModels {

    public class MovieFormViewModel {
        // Encapsulates all the data needed by the MovieForm
        // view & holds a reference to Movie.
        public List<Genre> Genres { get; set; }
        public Movie Movie { get; set; }

        public string Title {
             get {
                 if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";
                 else
                    return "New Movie";
             }
        }
    }
}