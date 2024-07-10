using ShopPro.Common.Data.Repository;

namespace ShopPro.Modules.Domain.Interfaces
{
    public interface IOrderDetailsRepository : IBaseRepository<Domain.Entities.OrderDetails, int>
    {
        List<Modules.Domain.Entities.OrderDetails> GetOrderDetails(int orderdetailsId);
    }
}
