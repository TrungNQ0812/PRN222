using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project2.DAL;
using Project2.Models;

namespace Project2.Pages
{
    public class AuthorModel : PageModel
    {

        private readonly LibraryManagementContext _libraryManagementContext;

        public AuthorModel(LibraryManagementContext context)
        {
            _libraryManagementContext = context;
        }

        [BindProperty]
        public List<Author> Authors { get; set; } = new();

        [BindProperty]
        public List<Book> Books { get; set; } = new();

        [BindProperty]
        public int? AuthorId { get; set; }

        public void OnGet()
        {

            Authors = _libraryManagementContext.Authors.ToList();
            Books = _libraryManagementContext.Books.ToList();


            Authors = _libraryManagementContext.Authors
                .Include(a => a.Books).ToList();
        }
    }
}
