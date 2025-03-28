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
    public class CreateModel : PageModel
    {
        private readonly INewsService _newsService;
        private readonly ITagService _tagService;
        public List<Models.Category> Categories { get; set; } = new();
        public List<Models.Tag> Tags { get; set; } = new();

        [BindProperty]
        public Models.NewsArticle News { get; set; } = new()
        {
            NewsStatus = true // Mặc định là Active (1)
        };
        [BindProperty]
        public List<int> SelectedTags { get; set; } = new();
        public CreateModel(INewsService newsService, ITagService tagService)
        {
            _newsService = newsService;
            _tagService = tagService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _newsService.GetCategoriesAsync();
            Tags = await _tagService.GetAllTagsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Categories = await _newsService.GetCategoriesAsync();
                Tags = await _tagService.GetAllTagsAsync();
                return Page();
            }

            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (userId == 0) return RedirectToPage("/Login");

            // Thêm Tags vào bài báo
            News.Tags = await _tagService.GetTagsByIdsAsync(SelectedTags);

            await _newsService.CreateAsync(News, (short)userId);
            return RedirectToPage("Index");
        }


    }
}
