using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NguyenQuangTrung_MVC.Filter;
using NguyenQuangTrung_MVC.Models;
using NguyenQuangTrung_MVC.Repository;

namespace NguyenQuangTrung_MVC.Controllers
{
    [AuthorizeRole("1")]//Chỉ dành cho Staff
    public class ProfileController : Controller
    {
        private readonly SystemAccountRepository _accountRepo;

        public ProfileController(SystemAccountRepository accountRepo)
        {
            this._accountRepo = accountRepo ?? throw new ArgumentNullException();
        }
        // GET: ProfileController
        public ActionResult Index()
        {
            var email = HttpContext.Session.GetString("Email");
            var acc = _accountRepo.GetSystemAccountByEmail(email);
            return View(acc);
        }

        // GET: ProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            var email = HttpContext.Session.GetString("Email");
            var acc = _accountRepo.GetSystemAccountByEmail(email);
            return View(acc);
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemAccount acc)
        {
            var email = HttpContext.Session.GetString("Email");
            var exitsAcc = _accountRepo.GetSystemAccountByEmail(email);
            exitsAcc.AccountEmail = acc.AccountEmail;
            exitsAcc.AccountName = acc.AccountName;
            exitsAcc.AccountPassword = acc.AccountPassword;
            _accountRepo.UpdateAccount(exitsAcc);
            return View();
        }

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
