using System.Data.Entity;

namespace MovieBase.Models {

    public class MyDbContext : DbContext {
        // Created in order to be able to migrate via Entity Framework.
        public MyDbContext() {}
    }
}