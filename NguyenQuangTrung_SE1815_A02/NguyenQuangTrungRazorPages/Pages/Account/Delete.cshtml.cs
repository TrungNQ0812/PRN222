using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Services;

namespace NguyenQuangTrungRazorPages.Pages.Account
{


    public class DeleteModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DeleteModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public SystemAccount Account { get; set; }

        public async Task<IActionResult> OnPostAsync(short accountId)
        {
            if (accountId == 0)
            {
                return NotFound();
            }

            await _accountService.DeleteAsync(accountId);
            return RedirectToPage("Index"); // Quay lại danh sách sau khi xóa
        }
    }


}
