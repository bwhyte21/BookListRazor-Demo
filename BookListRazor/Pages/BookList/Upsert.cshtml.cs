using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookListRazor.Pages.BookList
{
  public class UpsertModel : PageModel
  {
    private ApplicationDbContext _db;

    public UpsertModel(ApplicationDbContext db)
    {
      _db = db;
    }

    [BindProperty]
    public Book Book { get; set; }

    public async Task<IActionResult> OnGet(int? id)
    {
      // Create
      Book = new Book();
      if (id == null)
      {
        return Page();
      }

      // Update
      Book = await _db.Book.FirstOrDefaultAsync(b => b.Id == id);
      if (Book == null)
      {
        return NotFound();
      }
      return Page();
    }

    public async Task<IActionResult> OnPost()
    {
      if (ModelState.IsValid)
      {
        if (Book.Id == 0)
        {
          _db.Book.Add(Book);
        }
        else
        {
          // If you want to update EVERY property of the book.
          _db.Book.Update(Book);
        }

        await _db.SaveChangesAsync();

        return RedirectToPage("Index");
      }

      return RedirectToPage();
    }
  }
}