using MediChain.Models;

namespace MediChain.Repository.IRepository
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        public void Update(AppUser appUser);
    }
}
