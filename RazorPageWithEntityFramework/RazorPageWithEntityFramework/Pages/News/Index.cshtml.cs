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
    public class IndexModel : PageModel
    {
        private readonly RazorPageWithEntityFramework.DAL.FuNewsManagementContext _context;

        public IndexModel(RazorPageWithEntityFramework.DAL.FuNewsManagementContext context)
        {
            _context = context;
        }

        public IList<NewsArticle> NewsArticle { get;set; } = default!;

        public async Task OnGetAsync()
        {
            NewsArticle = await _context.NewsArticles
                .Include(n => n.Category)
                .Include(n => n.CreatedBy).ToListAsync();
        }
    }
}
