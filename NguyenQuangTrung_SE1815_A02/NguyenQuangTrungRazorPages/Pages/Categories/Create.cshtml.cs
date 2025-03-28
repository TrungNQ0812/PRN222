using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Services;

namespace NguyenQuangTrungRazorPages.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public CreateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public Models.Category Category { get; set; } = new();

        public List<Models.Category> ParentCategories { get; set; } = new();

        public async Task OnGetAsync()
        {
            ParentCategories = await _categoryService.GetAllCategoryAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ParentCategories = await _categoryService.GetAllCategoryAsync();
                return Page();
            }

            await _categoryService.CreateAsync(Category);
            return RedirectToPage("Index");
        }
    }

}
