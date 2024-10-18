using MediChain.Models;
using MediChain.Models.ViewModels;
using MediChain.Repository.IRepository;
using MediChain.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediChain.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork repo;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IUnitOfWork _repo, IWebHostEnvironment _webHostEnvironment)
        {
            repo = _repo;
            webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = repo.Product.GetAll(includeProperties:"Category").ToList();
            return View(objProductList);
        }
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = repo.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                })
            };
            if (id == null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = repo.Product.Get(u => u.ProductId == id);
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if(productVM.Product.ProductName == productVM.Product.Description)
            {
                ModelState.AddModelError("", "The Description cannot exactly match the ProductName.");
            }
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var uploads = Path.Combine(wwwRootPath, @"images\products");

                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath,productVM.Product.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.ImageUrl = @"\images\products\" + fileName;
                }
                if(productVM.Product.ProductId == 0)
                {
                    repo.Product.Add(productVM.Product);
                    TempData["success"] = "Product has been added successfully.";
                }
                else
                {
                    repo.Product.Update(productVM.Product);
                    TempData["success"] = "Product has been updated successfully.";
                }
                repo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = repo.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                });
                return View(productVM);
            }
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? product = repo.Product.Get(u => u.ProductId == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? product = repo.Product.Get(u => u.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            repo.Product.Remove(product);
            repo.Save();
            TempData["success"] = "Product has been deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
