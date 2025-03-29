using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrungNQ_Project_PRN222.Models;
using TrungNQ_Project_PRN222.Repositories;

namespace TrungNQ_Project_PRN222.Controllers
{
    public class DocumentsController : Controller
    {

        private readonly DocumentRepository DocuRepo;
        private readonly AccountRepository AccountRepo;


        public DocumentsController(DocumentRepository DocumentRepository, AccountRepository AccountRepository)
        {
            DocuRepo = DocumentRepository;
            AccountRepo = AccountRepository;
        }

        // GET: DocumentsController
        public ActionResult Index()
        {
            var model = DocuRepo.GetAllDocumentActive();
            return View(model);
        }

        // GET: DocumentsController/Details/5
        public ActionResult Details(int id)
        {
            var details = DocuRepo.GetByID(id);
            return View(details);
        }

        // GET: DocumentsController/Create
        public ActionResult Create()
        {
            var accountId = HttpContext.Session.GetString("AccountID");
            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Account"); // Chuyển hướng nếu chưa đăng nhập
            }

            ViewBag.AccountId = int.Parse(accountId); // Truyền AccountId vào ViewBag

            ViewBag.DocumentStatusId = new List<SelectListItem>
    {
        new SelectListItem { Value = "1", Text = "Pending" },
        new SelectListItem { Value = "2", Text = "Approved" },
        new SelectListItem { Value = "3", Text = "Released" },
        new SelectListItem { Value = "4", Text = "Rejected" },
        new SelectListItem { Value = "5", Text = "Canceled" }
    };

            ViewBag.CategoryId = new List<SelectListItem>
    {
        new SelectListItem { Value = "1", Text = "Public" },
        new SelectListItem { Value = "2", Text = "Internal" },
        new SelectListItem { Value = "3", Text = "Confidential" },
        new SelectListItem { Value = "4", Text = "Restricted" }
    };

            return View();
        }

        // POST: DocumentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Document document)
        {
            var accountId = HttpContext.Session.GetString("AccountID");
            ViewBag.AccountId = int.Parse(accountId); // Truyền AccountId vào ViewBag

            ViewBag.DocumentStatusId = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Pending" },
                new SelectListItem { Value = "2", Text = "Approved" },
                new SelectListItem { Value = "3", Text = "Released" },
                new SelectListItem { Value = "4", Text = "Rejected" },
                new SelectListItem { Value = "5", Text = "Canceled" }
            };

            ViewBag.CategoryId = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Public" },
                new SelectListItem { Value = "2", Text = "Internal" },
                new SelectListItem { Value = "3", Text = "Confidential" },
                new SelectListItem { Value = "4", Text = "Restricted" }
            };

            if (string.IsNullOrEmpty(accountId))
            {
                ModelState.AddModelError("", "Bạn cần đăng nhập để tạo tài liệu.");
                return View(document);
            }

            document.AccountId = int.Parse(accountId); // Gán AccountId từ session
            document.CreateAt = DateTime.Now;
            document.UpdateAt = DateTime.Now;

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(document);
            }


            try
            {
                DocuRepo.AddDocument(document);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi lưu dữ liệu: " + ex.Message);
                return View(document);
            }

        }

        // GET: DocumentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: DocumentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentsController/Delete/5
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
