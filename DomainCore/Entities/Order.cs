using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Entities
{
    public class Order : BaseEntity
    {
        public List<OrderItem> OrderItems { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
