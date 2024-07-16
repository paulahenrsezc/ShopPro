using ShopPro.Modules.Domain.Entities;
using ShopPro.Modules.Persistence.Context;

namespace ShopPro.Modules.Persistence.Extentions
{
    public static class OrderDetailsExtentions
    {
        public static void UpdateFromEntity(this OrderDetails orderdetailsToUpdate, OrderDetails entity)
        {
            orderdetailsToUpdate.productid = entity.productid;
            orderdetailsToUpdate.unitprice = entity.unitprice;
            orderdetailsToUpdate.qty = entity.qty;
            orderdetailsToUpdate.discount = entity.discount;
        }

        public static OrderDetails ValidateOrderDetailsExists(this ShopContext context, int orderid)
        {
            var orderdetails = context.OrderDetails.Find(orderid);
            return orderdetails;
        }
    }
}
