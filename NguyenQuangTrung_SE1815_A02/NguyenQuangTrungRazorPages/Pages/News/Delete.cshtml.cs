using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NguyenQuangTrungRazorPages.Services;
using System.Threading.Tasks;

namespace NguyenQuangTrungRazorPages.Pages.News
{
    public class DeleteModel : PageModel
    {
        private readonly INewsService _newsService;

        public DeleteModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        [BindProperty]
        public string NewsArticleId { get; set; } = null!;

        public async Task<IActionResult> OnPostAsync()
        {
            await _newsService.DeleteAsync(NewsArticleId);
            return RedirectToPage("Index");
        }
    }
}
