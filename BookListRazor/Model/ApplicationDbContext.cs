using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
  public class ApplicationDbContext : DbContext
  {
    // Pass DbContext options to the parent class
    // "options" is needed for dependency injection
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    // Add book model that was added to db
    public DbSet<Book> Book { get; set; }
  }
}
