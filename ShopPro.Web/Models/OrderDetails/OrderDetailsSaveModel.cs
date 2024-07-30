namespace ShopPro.Web.Models.OrderDetails
{
    public class OrderDetailsSaveModel
    {
        public int orderid { get; set; }
        public int productid { get; set; }
        public int unitprice { get; set; }
        public int qty { get; set; }
        public int discount { get; set; }
    }
}
