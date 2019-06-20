using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Messenger { get; set; }

        public void OnGet(int id)
        {
            Book = _db.Books.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFormDb = _db.Books.Find(Book.Id); //láy book theo id
                BookFormDb.Name = Book.Name;
                BookFormDb.Author = Book.Author;
                BookFormDb.ISBN = Book.ISBN;

                await _db.SaveChangesAsync();

                Messenger = "Book has been updated successfully";
                return RedirectToPage("Index");

            }
            return RedirectToPage("Index");
        }
    }
}