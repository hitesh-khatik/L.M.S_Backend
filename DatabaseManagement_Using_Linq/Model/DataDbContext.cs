using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DatabaseManagement_Using_Linq.Model
{
    public class DataDbContext : DbContext
    {

        public DataDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
       public DbSet<BooksCategory>Bookscatagory { get; set; }
       public DbSet<Books>books { get; set; }
    }
}
