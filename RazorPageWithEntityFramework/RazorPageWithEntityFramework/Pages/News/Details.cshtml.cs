using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageWithEntityFramework.DAL;
using RazorPageWithEntityFramework.Models;

namespace RazorPageWithEntityFramework.Pages.News
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPageWithEntityFramework.DAL.FuNewsManagementContext _context;

        public DetailsModel(RazorPageWithEntityFramework.DAL.FuNewsManagementContext context)
        {
            _context = context;
        }

        public NewsArticle NewsArticle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsarticle = await _context.NewsArticles.FirstOrDefaultAsync(m => m.NewsArticleId == id);
            if (newsarticle == null)
            {
                return NotFound();
            }
            else
            {
                NewsArticle = newsarticle;
            }
            return Page();
        }
    }
}
