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
    }
}
