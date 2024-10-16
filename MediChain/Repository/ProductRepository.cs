using MediChain.Data;
using MediChain.Models;
using MediChain.Repository.IRepository;

namespace MediChain.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext db;
        public ProductRepository(AppDbContext _db) : base(_db)
        {
            db = _db;
        }
        public void Update(Product product)
        {
            var objFromDb = db.Products.FirstOrDefault(s => s.ProductId == product.ProductId);
            if (objFromDb != null)
            {
                if (product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
                objFromDb.ProductName = product.ProductName;
                objFromDb.Description = product.Description;
                objFromDb.Price = product.Price;
                objFromDb.CategoryId = product.CategoryId;
            }
        }
    }
}
