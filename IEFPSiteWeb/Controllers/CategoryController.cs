using IEFPSiteWeb.Data;
using IEFPSiteWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace IEFPSiteWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomerError", "The Display Order cannot match the Name Field."); /*Adicionar erro ao modelo para ser invalido*/
            }

            if (ModelState.IsValid)
            {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index"); //("Index", "Home") para ir ao controlador home
            }

            return View(obj);
        }
    }
}
