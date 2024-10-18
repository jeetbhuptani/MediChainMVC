using MediChain.Models;

namespace MediChain.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        public void Update(OrderDetail orderDetail);
    }
}
