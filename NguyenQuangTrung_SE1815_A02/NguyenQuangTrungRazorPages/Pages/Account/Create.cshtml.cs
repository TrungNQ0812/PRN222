using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Services;

namespace NguyenQuangTrungRazorPages.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accountService;

        [BindProperty]
        public SystemAccount Account { get; set; } = new();

        public CreateModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _accountService.AddAsync(Account);
            return RedirectToPage("Index");
        }
    }


}
