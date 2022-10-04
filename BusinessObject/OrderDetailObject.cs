using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObject
{
    public partial class OrderDetailObject
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public virtual OrderObject Order { get; set; }
        public virtual ProductObject Product { get; set; }
    }
}
