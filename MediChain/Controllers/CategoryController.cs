using MediChain.Data;
using MediChain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediChain.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext db;
        public CategoryController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(category.CategoryName == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "The DisplayOrder cannot exactly match the CategoryName.");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                TempData["success"] = "Category has been added successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category? category = db.Categories.FirstOrDefault<Category>(u => u.CategoryId==id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Update(obj);
                db.SaveChanges();
                TempData["success"] = "Category has been updated successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = db.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            TempData["success"] = "Category has been deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
