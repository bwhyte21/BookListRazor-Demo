using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookListRazor.Pages.BookList
{
  public class CreateModel : PageModel
  {
    private readonly ApplicationDbContext _db;

    public CreateModel(ApplicationDbContext db)
    {
      _db = db;
    }

    [BindProperty]
    public Book Book { get; set; }

    public static void OnGet()
    {
      // Methed left empty intentionally.
    }

    // On handler for posting a new book object.
    public async Task<IActionResult> OnPost()
    {
      if (ModelState.IsValid)
      {
        // Add the book to the database.
        await _db.Book.AddAsync(Book);
        // Save the changes to the database from the queue.
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
      }
      else { return Page(); }
    }
  }
}