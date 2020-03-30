using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
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
      // Extract application dbcontext that is inside the dependency injection container.
      _db = db;
    }

    public IEnumerable<Book> Books { get; set; }

    // Book Index GetHandler
    public async Task OnGet()
    {
      // Show the list of books in the database.
      Books = await _db.Book.ToListAsync();
    }

    // Delete Book PostHandler
    public async Task<IActionResult> OnPostDelete(int id)
    {
      // Search the database for the book entry of choice.
      var book = await _db.Book.FindAsync(id);

      // If the selected book entry is not found, let the user know.
      if (book == null)
      {
        return NotFound();
      }

      // Remove selected book entry.
      _db.Book.Remove(book);

      // Save changes to database.
      await _db.SaveChangesAsync();

      // Reload page after entry deletion.
      return RedirectToPage("Index");
    }
  }
}