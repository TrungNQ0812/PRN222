using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Services;

namespace NguyenQuangTrungRazorPages.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public EditModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public Models.Category Category { get; set; } = new();

        public List<Models.Category> ParentCategories { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(short id)
        {
            Category = await _categoryService.GetByIdAsync(id);
            if (Category == null) return NotFound();

            ParentCategories = await _categoryService.GetAllCategoryAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ParentCategories = await _categoryService.GetAllCategoryAsync();
                return Page();
            }

            await _categoryService.UpdateAsync(Category);
            return RedirectToPage("Index");
        }
    }
}
