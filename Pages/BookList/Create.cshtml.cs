using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData] //thuộc tính dữ liệu tạm thời
        public string Messenger { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty] //thuộc tính công khai của lớp cho phép truy cập ở các nơi khác
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Books.Add(Book);
            await _db.SaveChangesAsync();
            Messenger = "Book has been create successfully";
            return RedirectToPage("Index");
        }
    }
}