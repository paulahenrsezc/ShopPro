using ShopPro.Modules.Application.Dtos.OrderDetails;
using ShopPro.Modules.Domain.Entities;
using ShopPro.Modules.Persistence.Context;
using ShopPro.Modules.Persistence.Exceptions;

namespace ShopPro.Modules.Persistence.Extentions
{
    public static class OrderDetailsExtentions
    {
        public static OrderDetailsBaseDto ConvertOrdEntityOrderDetailsDto(this OrderDetails orderdetails)
        {
            OrderDetailsBaseDto orderdetailsDto = new OrderDetailsBaseDto()
            {
                productid = orderdetails.productid,
                unitprice = orderdetails.unitprice,
                qty = orderdetails.qty,
                discount = orderdetails.discount
            };

            return orderdetailsDto;
        }

        public static OrderDetails ValidateOrderDetailsExists(this ShopContext context, int orderid)
        {
            var orderdetails = context.OrderDetails.Find(orderid);
            if (orderdetails == null)
            {
                throw new OrderDetailsRepositoryException("La orden no fue encontrada");
            }
            return orderdetails;
        }

        public static void UpdateFromDtos(this OrderDetails orderdetails, OrderDetailsUpdateDto orderdetailsUpdate)
        {
            orderdetailsUpdate.orderid = orderdetailsUpdate.orderid;
            orderdetailsUpdate.productid = orderdetailsUpdate.productid;
            orderdetailsUpdate.unitprice = orderdetailsUpdate.unitprice;
            orderdetailsUpdate.qty = orderdetailsUpdate.qty;
            orderdetailsUpdate.discount = orderdetailsUpdate.discount;

        }
    }
}
