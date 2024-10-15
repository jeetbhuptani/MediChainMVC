using MediChain.Data;
using MediChain.Models;
using MediChain.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MediChain.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository repo;
        public CategoryController(ICategoryRepository _repo)
        {
            repo = _repo;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = repo.GetAll().ToList();
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
                repo.Add(category);
                repo.Save();
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
            Category? category = repo.Get(u => u.CategoryId==id);
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
                repo.Update(obj);
                repo.Save();
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
            Category? category = repo.Get(u => u.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = repo.Get(u => u.CategoryId == id);
            if(category == null)
            {
                return NotFound();
            }
            repo.Remove(category);
            repo.Save();
            TempData["success"] = "Category has been deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
