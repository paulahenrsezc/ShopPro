using ShopPro.Web.Models.OrderDetails;
using ShopPro.Web.Models.OrderDetails.Results;

namespace ShopPro.Web.Interfaces
{
    public interface IOrderDetailsService
    {
        Task<OrderDetailsListGetResult> GetList();
        Task<OrderDetailsGetResult> GetById(int id);
        Task<OrderDetailsGetResult> Save(OrderDetailsSaveModel orderDetailsSave);
        Task<OrderDetailsGetResult> Update(OrderDetailsUpdateModel orderDetailsUpdate);
        Task<OrderDetailsUpdateModel> GetUpdateModelById(int id);
    }
}
