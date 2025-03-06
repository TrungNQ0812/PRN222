using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenQuangTrung_MVC.Filter;
using NguyenQuangTrung_MVC.Models;
using NguyenQuangTrung_MVC.Repository;

namespace NguyenQuangTrung_MVC.Controllers
{
    [AuthorizeRole("0")] // Chỉ dành cho admin
    public class AdminController : Controller
    {
        private readonly SystemAccountRepository _accountRepo;

        public AdminController(SystemAccountRepository accountRepo)
        {
            this._accountRepo = accountRepo ?? throw new ArgumentNullException();
        }

        // GET: AdminController
        public ActionResult Index()
        {
            var finder = _accountRepo.GetAllSystemAccounts();
            return View(finder);
        }

        // GET
        public ActionResult Details(int id)
        {
            var finder = _accountRepo.GetAccountById(id);
            return View(finder);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            ViewBag.RoleList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Staff" },
                new SelectListItem { Value = "2", Text = "Lecturer" }
            };
            ViewBag.NextId = _accountRepo.GetAccountCount() + 1;
            ViewBag.StatusList = _accountRepo.GetAllAccountStatus();
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemAccount acc)
        {
            ViewBag.RoleList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Staff" },
                new SelectListItem { Value = "2", Text = "Lecturer" }
            };
            ViewBag.NextId = _accountRepo.GetAccountCount() + 1;
            ViewBag.StatusList = _accountRepo.GetAllAccountStatus();
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
                return View(acc);
            }

            _accountRepo.AddNewAcc(acc);
            return RedirectToAction("Index");

        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            SystemAccount acc = _accountRepo.GetAccountById(id);
            ViewBag.StatusList = _accountRepo.GetAllAccountStatus();
            ViewBag.RoleList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Staff" },
                new SelectListItem { Value = "2", Text = "Lecturer" }
            };
            return View(acc);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemAccount acc)
        {
            

            var existingAccount = _accountRepo.GetAccountById(id);
            ViewBag.StatusList = ViewBag.StatusList = _accountRepo.GetAllAccountStatus();
            ViewBag.RoleList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Staff" },
                new SelectListItem { Value = "2", Text = "Lecturer" }
            };
            if (acc.AccountId == 0) 
            {
                acc.AccountId = (short)id;
            }


            if (existingAccount == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(acc);
            }
            existingAccount.AccountId = acc.AccountId;
            existingAccount.AccountStatus = acc.AccountStatus;
            existingAccount.AccountEmail = acc.AccountEmail;
            existingAccount.AccountRole = acc.AccountRole;
            existingAccount.AccountName = acc.AccountName;
            existingAccount.AccountPassword = acc.AccountPassword;

            _accountRepo.UpdateAccount(existingAccount);

            return RedirectToAction("Index");

        }

        // GET: AdminController/Delete
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var account = _accountRepo.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }

            _accountRepo.DeleteAccount(id);
            return RedirectToAction("Index");
        }
    }
}
