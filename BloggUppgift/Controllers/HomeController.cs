using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BloggUppgift.Models;
using BloggUppgift.ViewModels;
using BloggUppgift.Models.Interface;
using BloggUppgift.Models.Services;

namespace BloggUppgift.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
           var model = Services.Instance.GetAllCategories();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBlogg(ArchiveBloggViewModel model)
        {
            if(ModelState.IsValid)
            {
                Services.Instance.CreateNewBlogg(model);
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                model = Services.Instance.GetAllCategories();
                return View(nameof(Index),model);
            }
        }

        public IActionResult ArchivedPosts()
        {

            var model = Services.Instance.GetAll();
            model.BloggCategories = Services.Instance.GetAllCategories().BloggCategories;

            return View(model);
        }
        [HttpGet]
        public IActionResult GetBySearch(ArchiveBloggViewModel model)
        {
            model = Services.Instance.GetBloggs(model);
            model.BloggCategories = Services.Instance.GetAllCategories().BloggCategories;
            return View(model);
        }
        public IActionResult ViewBloggPost(int id)
        {
            var model = Services.Instance.GetBloggDetails(id);
            model.BloggCategories = Services.Instance.GetAllCategories().BloggCategories;
            return View(model);
        }

    }
}
