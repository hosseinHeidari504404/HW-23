using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Entities
{
    public class OrderItem : BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => UnitPrice * Count;

    }
}
