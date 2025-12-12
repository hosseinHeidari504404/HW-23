using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<Order>? Orders { get; set; }
        public Wallet Wallet { get; set; }
        public int WalletId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
