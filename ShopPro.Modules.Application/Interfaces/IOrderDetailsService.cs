using ShopPro.Modules.Application.Core;
using ShopPro.Modules.Application.Dtos.OrderDetails;

namespace ShopPro.Modules.Application.Interfaces
{
    public interface IOrderDetailsService
    {
        ServiceResult GetOrderDetails();
        ServiceResult GetOrderDetails(int id);
        ServiceResult UpdateOrderDetails(OrderDetailsUpdateDto orderDetailsUpdate);
        ServiceResult RemoveOrderDetails(OrderDetailsRemoveDto orderDetailsRemove);
        ServiceResult SaveOrderDetails(OrderDetailsSaveDto orderDetailsSave);

    }
}
