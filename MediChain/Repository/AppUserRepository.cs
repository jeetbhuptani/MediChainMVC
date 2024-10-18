using MediChain.Data;
using MediChain.Models;
using MediChain.Repository.IRepository;

namespace MediChain.Repository
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private AppDbContext _db;
        public AppUserRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(AppUser appUser)
        {
            _db.AppUsers.Update(appUser);
        }
    }
}
