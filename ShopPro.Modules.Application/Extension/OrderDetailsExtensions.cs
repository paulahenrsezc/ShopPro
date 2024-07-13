using ShopPro.Modules.Application.Dtos.OrderDetails;
using ShopPro.Modules.Domain.Entities;

namespace ShopPro.Modules.Application.Extension
{
    public static class OrderDetailsExtensions
    {

        public static OrderDetails ToEntity(this OrderDetailsRemoveDto dto)
        {
            return new OrderDetails
            {
                Id = dto.orderid,
                productid = dto.productid,
                unitprice = dto.unitprice,
                qty = dto.qty,
                discount = dto.discount
            };
        }

        public static OrderDetails ToEntity(this OrderDetailsSaveDto dto)
        {
            return new OrderDetails
            {
                Id = dto.orderid,
                productid = dto.productid,
                unitprice = dto.unitprice,
                qty = dto.qty,
                discount = dto.discount
            };
        }

        public static void UpdateFromDto(this OrderDetails orderdetails, OrderDetailsUpdateDto dto)
        {
            orderdetails.productid = dto.productid;
            orderdetails.unitprice = dto.unitprice;
            orderdetails.qty = dto.qty;
            orderdetails.discount = dto.discount;
        }

    }
}
