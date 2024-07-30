namespace ShopPro.Web.Models.OrderDetails
{
    public class OrderDetailsModel
    {
        public int id { get; set; }
        public int productid { get; set; }
        public int unitprice { get; set; }
        public int qty { get; set; }
        public double discount { get; set; }
    }
}
