using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.DAL;
using NguyenQuangTrungRazorPages.Services;

namespace NguyenQuangTrungRazorPages.Pages.Account
{
    public class UpdateProfileModel : PageModel
    {
        private readonly IAccountService _accountService;

        public UpdateProfileModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var accountId = HttpContext.Session.GetInt32("UserId");
            if (accountId == null)
            {
                return RedirectToPage("/Account/Login");

            }

            var existingAccount = await _accountService.GetProfileAsync((short)accountId);
            if (existingAccount == null)
            {
                return NotFound();
            }

            existingAccount.AccountName = Account.AccountName;
            existingAccount.AccountEmail = Account.AccountEmail;
            existingAccount.AccountPassword = Account.AccountPassword;

            await _accountService.UpdateProfileAsync(existingAccount);

            return RedirectToPage("/Account/ViewProfile");
        }
    }
}
