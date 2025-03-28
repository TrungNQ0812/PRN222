using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Services;

namespace NguyenQuangTrungRazorPages.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public DeleteModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public short CategoryId { get; set; } 

        

        public async Task<IActionResult> OnPostAsync()
        {
            await _categoryService.DeleteAsync(CategoryId);
            return RedirectToPage("Index");
        }
    }
}
