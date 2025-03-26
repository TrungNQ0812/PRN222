using Demo_ASP.NET_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP.NET_Core_MVC.Controllers
{
    public class CreatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductEditModel model)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                message = "product " + model.Name + " created successfully";
            }
            else
            {
                message = "Failed to create the product. Please try again";
            }
            return Content(message);
        }

    }
}
