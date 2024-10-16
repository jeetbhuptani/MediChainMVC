using MediChain.Data;
using MediChain.Models;
using MediChain.Repository.IRepository;
using MediChain.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediChain.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork repo;
        public CategoryController(IUnitOfWork _repo)
        {
            repo = _repo;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = repo.Category.GetAll().ToList();
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
                repo.Category.Add(category);
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
            Category? category = repo.Category.Get(u => u.CategoryId==id);
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
                repo.Category.Update(obj);
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
            Category? category = repo.Category.Get(u => u.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = repo.Category.Get(u => u.CategoryId == id);
            if(category == null)
            {
                return NotFound();
            }
            repo.Category.Remove(category);
            repo.Save();
            TempData["success"] = "Category has been deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
