using MediChain.Models;

namespace MediChain.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        public void Update(ShoppingCart shoppingCart);
    }
}
