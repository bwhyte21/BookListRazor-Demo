using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookListRazor.Pages.BookList
{
  public class IndexModel : PageModel
  {
    private readonly ApplicationDbContext _db;
    public IndexModel(ApplicationDbContext db)
    {
      // extract application dbcontext that is inside the dep inject container
      _db = db;
    }

    public IEnumerable<Book> Books { get; set; }

    // Book Index Get Handler
    public async Task OnGet()
    {
      Books = await _db.Book.ToListAsync();
    }
  }
}