using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Services;

namespace NguyenQuangTrungRazorPages.Pages.Account
{

    public class LoginModel : PageModel
    {

        private readonly IAccountService _accountService;
        private readonly AdminAccountSettings _adminSettings;


        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public LoginModel(IAccountService accountService, IOptions<AdminAccountSettings> adminSettings)
        {
            _accountService = accountService;
            _adminSettings = adminSettings.Value;
        }

        public IActionResult OnGet(string? action)
        {
            // Nếu URL có action=logout thì thực hiện đăng xuất
            if (action == "logout")
            {
                HttpContext.Session.Clear(); // Xóa session
                return RedirectToPage("/Account/Login"); // Quay lại trang đăng nhập
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _accountService.AuthenticateAsync(Email, Password);

            if (user == null && Email == _adminSettings.Email && Password == _adminSettings.Password)
            {
                user = new SystemAccount
                {
                    AccountId = _adminSettings.AccountId,
                    AccountName = _adminSettings.AccountName,
                    AccountRole = _adminSettings.AccountRole
                };
            }

            if (user == null)
            {
                ErrorMessage = "Invalid email or password";
                return Page();
            }

            HttpContext.Session.SetInt32("UserId", user.AccountId);
            HttpContext.Session.SetInt32("UserRole", user.AccountRole ?? 0);

            HttpContext.Session.SetString("UserName", user.AccountName);

            if (user.AccountRole == 1)
            {
                return RedirectToPage("/News/Lecturer");
            }
            else if (user.AccountRole == 2)
            {
                return RedirectToPage("/News/Index");
            }
            else if (user.AccountRole == 0)
            {
                return RedirectToPage("/Account/Index");
            }

            // ✅ Mặc định quay về trang tài khoản nếu không phải role 1 hoặc 2
            return RedirectToPage("/News/Lecturer");
        }
    }
}
