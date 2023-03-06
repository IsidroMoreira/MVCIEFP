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
                ModelState.AddModelError("Name", "The Display Order cannot match the Name Field."); /*Adicionar erro ao modelo para ser invalido*/
            }

            if (ModelState.IsValid)
            {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index"); //("Index", "Home") para ir ao controlador home
            }

            return View(obj);
        }

        //GET Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id==0) {
                return NotFound();
            }

            //Pesquisa a base dados exemplos
            Category? categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u=>u.Id == id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot match the Name Field."); /*Adicionar erro ao modelo para ser invalido*/
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); //("Index", "Home") para ir ao controlador home
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Pesquisa a base dados exemplos
            Category? categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u=>u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "The Display Order cannot match the Name Field."); /*Adicionar erro ao modelo para ser invalido*/
            //}

            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); //("Index", "Home") para ir ao controlador home
            }

            return View(obj);
        }
    }
}
