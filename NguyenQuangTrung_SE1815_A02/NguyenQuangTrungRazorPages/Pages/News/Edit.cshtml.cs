using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NguyenQuangTrungRazorPages.Pages.News
{
    public class EditModel : PageModel
    {
        private readonly INewsService _newsService;
        private readonly ITagService _tagService;

        public List<Models.Category> Categories { get; set; } = new();

        [BindProperty]
        public Models.NewsArticle News { get; set; } = new();

        public EditModel(INewsService newsService, ITagService tagService)
        {
            _newsService = newsService;
            _tagService = tagService;
        }

        public List<Models.Tag> AllTags { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            News = await _newsService.GetByIdAsync(id);
            if (News == null)
            {
                return NotFound();
            }

            Categories = await _newsService.GetCategoriesAsync();
            AllTags = await _tagService.GetAllTagsAsync(); // Lấy danh sách tags

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(List<int> tagIds)
        {
            if (!ModelState.IsValid)
            {
                Categories = await _newsService.GetCategoriesAsync();
                AllTags = await _tagService.GetAllTagsAsync();
                return Page();
            }

            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (userId == 0)
            {
                return RedirectToPage("/Login");
            }

            await _newsService.UpdateAsync(News, tagIds, (short)userId);
            return RedirectToPage("Index");
        }



    }
}
