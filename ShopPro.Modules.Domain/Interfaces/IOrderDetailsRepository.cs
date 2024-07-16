using ShopPro.Common.Data.Repository;

namespace ShopPro.Modules.Domain.Interfaces
{
    public interface IOrderDetailsRepository : IBaseRepository<Entities.OrderDetails, int>
    {
        List<Modules.Domain.Entities.OrderDetails> GetOrderDetailsById(int orderid);
    }
}