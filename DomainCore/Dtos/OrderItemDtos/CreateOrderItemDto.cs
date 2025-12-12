using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Dtos.OrderItemDtos
{
    public class CreateOrderItemDto
    {
        public int ProductId { get; set; }
        public int? OrderId { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
