namespace ShopPro.Web.Models.OrderDetails
{
    public class OrderDetailsSaveModel
    {
        public int orderid { get; set; }
        public int productid { get; set; }
        public decimal unitprice { get; set; }
        public short qty { get; set; }
        public decimal discount { get; set; }
    }
}
