using DomainCore.Dtos.OrderItemDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<CreateOrderItemDto> OrederItems { get; set; }
    }
}
