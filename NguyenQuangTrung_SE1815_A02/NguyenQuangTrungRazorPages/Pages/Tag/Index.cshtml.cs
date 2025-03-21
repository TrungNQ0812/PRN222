using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NguyenQuangTrungRazorPages.DAL;
using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Pages.Tag
{
    public class IndexModel : PageModel
    {
        private readonly NguyenQuangTrungRazorPages.DAL.FuNewsManagementContext _context;

        public IndexModel(NguyenQuangTrungRazorPages.DAL.FuNewsManagementContext context)
        {
            _context = context;
        }

        public IList<Models.Tag> Tag { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Tag = await _context.Tags.ToListAsync();
        }
    }
}
