using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NguyenQuangTrung_MVC.Repository;
using NguyenQuangTrung_MVC.Models;
using NguyenQuangTrung_MVC.Service;
using NguyenQuangTrung_MVC.DAL;
using Microsoft.AspNetCore.Authorization;
using NguyenQuangTrung_MVC.Filter;

namespace NguyenQuangTrung_MVC.Controllers
{
    public class NewsArticleController : Controller
    {

        private readonly CategoryRepository categoryRepo;

        private readonly NewsArticleRepository articleRepo;
        private readonly SystemAccountRepository accountRepo;

        private readonly IConfiguration configuration;

        public NewsArticleController(NewsArticleRepository articleRepo, CategoryRepository categoryRepo,
            SystemAccountRepository accountRepo, IConfiguration configuration)
        {
            this.articleRepo = articleRepo ?? throw new ArgumentNullException(nameof(articleRepo));
            this.categoryRepo = categoryRepo ?? throw new ArgumentNullException(nameof(categoryRepo));
            this.accountRepo = accountRepo ?? throw new ArgumentNullException(nameof(accountRepo));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        // GET: NewsArticleController
        public ActionResult Index()
        {
            var model = articleRepo.GetAllNewsArticlesActive();
            return View(model);
        }

        // GET: NewsArticleController/Details/5
        public ActionResult Details(int id)
        {
            var details = articleRepo.GetNewsById(id);  
            return View(details);
        }

        // GET: NewsArticleController/Create
        [AuthorizeRole("0", "1")] // Admin and Staff
        public ActionResult Create()
        {
            ViewBag.CategoryId = categoryRepo.GetAllCategoryID();
            //ViewBag.CreatedById = HttpContext.Session.GetString("Email") == configuration["AdminAccount:AccountEmail"]
            //    ? configuration["AdminAccount:AccountID"]
            //    : accountRepo.GetSystemAccountByEmail(HttpContext.Session.GetString("Email"))?.AccountId.ToString();

            return View();
        }


   


        // POST: NewsArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRole("0", "1")] // Admin and Staff
        public ActionResult Create(NewsArticle newsArticle)
        {
            ViewBag.CategoryId = categoryRepo.GetAllCategoryID();
            if (!ModelState.IsValid) // Kiểm tra lỗi nhập liệu
            {
                ViewBag.CategoryId = categoryRepo.GetAllCategoryID();
                return View(newsArticle); // Trả về form với lỗi
            }

            try
            {
                // Gán ngày tạo và người tạo
                newsArticle.CreatedDate = DateTime.Now;
                newsArticle.NewsStatus = true;
                //newsArticle.CreatedById = short.Parse(ViewBag.CreatedById.ToString());

                // Lưu vào DB
                articleRepo.Add(newsArticle);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error saving data: " + ex.Message);
                return View(newsArticle);
            }

        }

        // GET
        [AuthorizeRole("0", "1")] // Admin and Staff
        public ActionResult Edit(int id)
        {
            NewsArticle news = articleRepo.GetNewsById(id);
            return View(news);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRole("0", "1")] // Admin and Staff
        public ActionResult Edit(int id, NewsArticle newsArticle)
        {
            var existingArticle = articleRepo.GetNewsById(id);
            if (existingArticle == null)
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy bài viết
            }
            if (ModelState.IsValid)
            {
                existingArticle.NewsTitle = newsArticle.NewsTitle;
                existingArticle.Headline = newsArticle.Headline;
                existingArticle.NewsContent = newsArticle.NewsContent;
                existingArticle.NewsSource = newsArticle.NewsSource;
                existingArticle.CategoryId = newsArticle.CategoryId;
                existingArticle.NewsStatus = newsArticle.NewsStatus;
                existingArticle.ModifiedDate = DateTime.Now;
                articleRepo.Update(existingArticle);
                return RedirectToAction("Index");
            }
            return View(newsArticle);
            
        }



        // GET
        [AuthorizeRole("0","1")] // Admin and Staff
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST
        [AuthorizeRole("0", "1")] // Admin and Staff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
           articleRepo.deleteByID(id);
           return View();
            
        }
    }
}
