using ShopPro.Modules.Domain.Entities;
using ShopPro.Modules.Domain.Interfaces;
using System.Linq.Expressions;

namespace ShopPro.Modules.Persistence.Repositories
{
    internal class OrderDetailsRepository : IOrderDetailsRepository
    {
        public bool Exist(Expression<Func<OrderDetails, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetails GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetails> GetOrderDetails(int orderdetailsId)
        {
            throw new NotImplementedException();
        }

        public void Remove(OrderDetails entity)
        {
            throw new NotImplementedException();
        }

        public void Save(OrderDetails entity)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
