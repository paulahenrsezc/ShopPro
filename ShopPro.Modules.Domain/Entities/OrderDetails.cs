using ShopPro.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopPro.Modules.Domain.Entities
{
    [Table("OrderDetails", Schema = "Sales")]
    public class OrderDetails : BaseEntity<int>
    {
        [Key]
        [Column("orderid")]
        public override int Id { get; set; }
        public int productid { get; set; }
        public decimal unitprice { get; set; }
        public short qty { get; set; }
        public decimal discount { get; set; }
    }
}
