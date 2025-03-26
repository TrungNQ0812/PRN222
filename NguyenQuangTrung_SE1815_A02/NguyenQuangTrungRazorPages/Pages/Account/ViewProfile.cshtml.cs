using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Services;

namespace NguyenQuangTrungRazorPages.Pages.Account
{
    public class ViewProfileModel : PageModel
    {
        private readonly IAccountService _accountService;

        public ViewProfileModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public Models.SystemAccount Account { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var accountId = HttpContext.Session.GetInt32("UserId");
            if (accountId == null)
            {
                return RedirectToPage("/Account/Login");

            }

            Account = await _accountService.GetProfileAsync((short)accountId);
            if (Account == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
