using System.ComponentModel.DataAnnotations;

namespace ShopPro.Modules.Application.Dtos.OrderDetails
{
    public class OrderDetailsBaseDto
    {
        public int orderid { get; set; }
        public int productid { get; set; }

        [DataType(DataType.Currency)]
        public decimal unitprice { get; set; }
        public short qty { get; set; }

        [Range(0.000, 1.000, ErrorMessage = "Discount must be between 0.000 and 1.000")]
        public decimal discount { get; set; }
    }
}
