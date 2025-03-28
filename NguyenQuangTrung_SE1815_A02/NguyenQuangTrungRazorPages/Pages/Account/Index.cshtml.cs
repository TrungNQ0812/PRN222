using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NguyenQuangTrungRazorPages.DAL;
using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Pages.SystemAccount
{
    public class IndexModel : PageModel
    {
        private readonly NguyenQuangTrungRazorPages.DAL.FuNewsManagementContext _context;

        public IndexModel(NguyenQuangTrungRazorPages.DAL.FuNewsManagementContext context)
        {
            _context = context;
        }

        public IList<Models.SystemAccount> SystemAccount { get;set; } = default!;
        [BindProperty]
        public string? searchString { get; set; }
        [BindProperty]
        public string? accountStatus { get; set; }


        public async Task OnGetAsync()
        {
            var accounts = _context.SystemAccounts.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                accounts = accounts.Where(a => a.AccountName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(accountStatus))
            {
                accounts = accounts.Where(a => a.AccountStatus == accountStatus);
            }

            SystemAccount = await accounts.ToListAsync();
            //SystemAccount = await _context.SystemAccounts.ToListAsync();
        }
    }
}
