using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Dtos.OrderItemDtos
{
    public class GetOrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductImagePath { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
