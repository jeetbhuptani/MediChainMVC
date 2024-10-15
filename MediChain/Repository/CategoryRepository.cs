using MediChain.Data;
using MediChain.Models;
using MediChain.Repository.IRepository;

namespace MediChain.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext db;
        public CategoryRepository(AppDbContext _db) : base(_db)
        {
            db = _db;
        }

        public void Update(Category category)
        {
            db.Update(category);
        }
    }
}
