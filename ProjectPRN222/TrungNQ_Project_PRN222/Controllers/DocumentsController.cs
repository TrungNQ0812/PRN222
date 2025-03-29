using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using TrungNQ_Project_PRN222.Models;
using TrungNQ_Project_PRN222.Repositories;

namespace TrungNQ_Project_PRN222.Controllers
{
    public class DocumentsController : Controller
    {

        private readonly DocumentRepository DocuRepo;
        private readonly AccountRepository AccountRepo;
        private readonly DocumentStatusRepository DSRepo;
        private readonly CategoryRepository cateRepo;

        public DocumentsController(DocumentRepository DocumentRepository, AccountRepository AccountRepository,
            DocumentStatusRepository DocumentStatusRepository, CategoryRepository CategoryRepository)
        {
            DocuRepo = DocumentRepository;
            AccountRepo = AccountRepository;
            DSRepo = DocumentStatusRepository;
            cateRepo = CategoryRepository;
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

            ViewBag.DocumentStatusId = DSRepo.GetAllDocumentStatus().Select(ds => new SelectListItem
            {
                Value = ds.DocumentStatusId.ToString(),
                Text = ds.DocumentStatusName
            }).ToList();

            ViewBag.CategoryId = cateRepo.loadAllCategory().Select(ds => new SelectListItem
            {
                Value = ds.CategoryId.ToString(),
                Text = ds.CategoryName
            }).ToList();

            return View();
        }

        // POST: DocumentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Document document)
        {
            //var DocumentList = 
            var accountId = HttpContext.Session.GetString("AccountID");

            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Account"); // Chuyển hướng nếu chưa đăng nhập
            }
            ViewBag.AccountId = int.Parse(accountId); // Truyền AccountId vào ViewBag

            ViewBag.DocumentStatusId = DSRepo.GetAllDocumentStatus().Select(ds => new SelectListItem
            {
                Value = ds.DocumentStatusId.ToString(),
                Text = ds.DocumentStatusName
            }).ToList();

            ViewBag.CategoryId = cateRepo.loadAllCategory().Select(ds => new SelectListItem
            {
                Value = ds.CategoryId.ToString(),
                Text = ds.CategoryName
            }).ToList();

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
            var accountId = HttpContext.Session.GetString("AccountID");

            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Account"); // Chuyển hướng nếu chưa đăng nhập
            }
            return View();
        }

        // POST: DocumentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            var accountId = HttpContext.Session.GetString("AccountID");

            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Account"); // Chuyển hướng nếu chưa đăng nhập
            }
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
            var accountId = HttpContext.Session.GetString("AccountID");

            if (string.IsNullOrEmpty(accountId))
            {
                return RedirectToAction("Login", "Account"); // Chuyển hướng nếu chưa đăng nhập
            }

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
