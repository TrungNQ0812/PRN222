using Microsoft.AspNetCore.Mvc;
using NguyenQuangTrung_MVC.Models;
using NguyenQuangTrung_MVC.Repository;
using System.Diagnostics;

namespace NguyenQuangTrung_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly SystemAccountRepository _accountRepository;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, SystemAccountRepository accRepo)
        {
            _logger = logger;
            _configuration = configuration;
            _accountRepository = accRepo;
        }

        public IActionResult Index()
        {
            string role = HttpContext.Session.GetString("Role");
            _logger.LogInformation($"Current Role: {role}");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginTo(string Email, string Password)
        {
            // 🔹 Lấy thông tin Admin từ appsettings.json
            string AdminAccount = _configuration["AdminAccount:AccountEmail"];
            string AdminPassword = _configuration["AdminAccount:AccountPassword"];
            string AdminRole = _configuration["AdminAccount:Role"];
            string AdminID = _configuration["AdminAccount:AccountID"];

            // 🔹 Nếu tài khoản khớp với Admin trong appsettings.json
            if (Email.Equals(AdminAccount) && Password.Equals(AdminPassword))
            {
                HttpContext.Session.SetString("AccountID", AdminID);
                HttpContext.Session.SetString("Email", AdminAccount);
                HttpContext.Session.SetString("Role", AdminRole);

                return RedirectToAction("Index");
            }

            // 🔹 Kiểm tra tài khoản trong DB
            var findInDB = _accountRepository.GetSystemAccountByEmail(Email);
            if (findInDB == null || string.IsNullOrEmpty(findInDB.AccountPassword))
            {
                TempData["ErrorMessage"] = "Email hoặc mật khẩu không đúng!";
                return RedirectToAction("Login");
            }

            // 🔹 Kiểm tra mật khẩu
            if (!findInDB.AccountPassword.Equals(Password))
            {
                ViewBag.ErrorMessage = "Email or password is incorrect";
                return View("Login");
            }

            // 🔹 Kiểm tra role hợp lệ (0 = Admin, 1 = Staff, 2 = User)
            if (findInDB.AccountRole == 0 || findInDB.AccountRole == 1 || findInDB.AccountRole == 2)
            {
                HttpContext.Session.SetString("AccountID", findInDB.AccountId.ToString());
                HttpContext.Session.SetString("Email", Email);
                HttpContext.Session.SetString("Role", findInDB.AccountRole.ToString());

                return RedirectToAction("Index");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult AccessDenied()
        {
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Xóa toàn bộ session
            return RedirectToAction("Index"); // Chuyển về trang đăng nhập
        }

    }
}
