using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Entities
{
    public class Wallet : BaseEntity
    {
        public decimal Amount { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
