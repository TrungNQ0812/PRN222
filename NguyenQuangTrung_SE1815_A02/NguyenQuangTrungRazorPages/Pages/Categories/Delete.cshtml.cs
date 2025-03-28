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

        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            //await _categoryService.DeleteAsync(CategoryId);
            //return RedirectToPage("Index");
            bool isDeleted = await _categoryService.DeleteAsync(CategoryId);

            if (isDeleted)
            {
                return RedirectToPage("Index"); // Xóa thành công → về trang danh sách
            }
            else
            {
                ErrorMessage = "Cannot delete this category because it is being used in news articles.";
                return Page(); // Xóa thất bại → Hiển thị thông báo lỗi
            }
        }
    }
}
