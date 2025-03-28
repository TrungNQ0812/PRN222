using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Diagnostics;
using TrungNQ_Project_PRN222.Models;
using TrungNQ_Project_PRN222.Repositories;

namespace TrungNQ_Project_PRN222.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly AccountRepository _accountRepository;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, AccountRepository accountRepository)
        {
            _logger = logger;
            _configuration = configuration;
            _accountRepository = accountRepository;
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

        public IActionResult Login()
        {
            return View();
        }

        public ActionResult LoginTo(string email, string password)
        {

            // Lay du lieu cua admin tu appsetting.json
            string AdminEmail = _configuration["AdminAccount:AccountEmail"];
            string AdminPassword = _configuration["AdminAccount:Password"];
            string AdminRoleId = _configuration["AdminAccount:RoleId"];
            string AdminID = _configuration["AdminAccount:AccountId"];

            // Neu tai khoan khop voi admin trong appsetting.json
            if (email.Equals(AdminEmail) && password.Equals(AdminPassword))
            {
                HttpContext.Session.SetString("AccountID", AdminID);
                HttpContext.Session.SetString("Email", AdminEmail);
                HttpContext.Session.SetString("RoleId", AdminRoleId);

                return RedirectToAction("Index");
            }


            //Neu khong phai tai khoan admin thi tim trong db
            var findInDB = _accountRepository.GetAccountByEmail(email);
            if (findInDB == null || string.IsNullOrEmpty(findInDB.Password))
            {
                TempData["ErrorMessage"] = "Email or password is incorrect!";
                return RedirectToAction("Login");
            }

            // 🔹 Kiểm tra mật khẩu
            if (!findInDB.Password.Equals(password))
            {
                TempData["ErrorMessage"] = "Email or password is incorrect!";
                return RedirectToAction("Login");
            }
            // 🔹 Kiểm tra role hợp lệ (1 = Manager, 2 = Leader, 3 = Staff, 4 = Fresher, 5 = Intern)
            if (findInDB.RoleId == 1 || findInDB.RoleId == 2 || findInDB.RoleId == 3 || findInDB.RoleId == 4 || findInDB.RoleId == 5)
            {
                HttpContext.Session.SetString("AccountID", findInDB.AccountId.ToString());
                HttpContext.Session.SetString("Email", email);
                HttpContext.Session.SetString("Role", findInDB.RoleId.ToString());

                return RedirectToAction("Index");
            }

            return View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




    }
}
