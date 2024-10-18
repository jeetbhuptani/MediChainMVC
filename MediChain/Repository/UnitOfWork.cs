using MediChain.Data;
using MediChain.Repository.IRepository;

namespace MediChain.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext db;
        public ICategoryRepository Category { get;private set; }
        public IProductRepository Product { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IAppUserRepository AppUser { get; private set; }

        public UnitOfWork(AppDbContext _db)
        {
            db = _db;
            Category = new CategoryRepository(db);
            Product = new ProductRepository(db);
            ShoppingCart = new ShoppingCartRepository(db);
            OrderHeader = new OrderHeaderRepository(db);
            OrderDetail = new OrderDetailRepository(db);
            AppUser = new AppUserRepository(db);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
