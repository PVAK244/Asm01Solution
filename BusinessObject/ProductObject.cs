using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObject
{
    public partial class ProductObject
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }

        public virtual CategoryObject Category { get; set; }
        public virtual ICollection<OrderDetailObject> OrderDetails { get; set; }
    }
}
