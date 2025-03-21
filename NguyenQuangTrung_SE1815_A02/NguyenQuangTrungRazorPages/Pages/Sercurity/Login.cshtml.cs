using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NguyenQuangTrungRazorPages.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Models.SystemAccount Input { get; set; } = new();

        public string ErrorMessage { get; set; }

        public void OnGet()
        {

        }

        private readonly IConfiguration configuration;
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if ()
            {

            }
        }
    }
}
