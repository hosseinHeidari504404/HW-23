using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Dtos.UserDtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal WalletCount { get; set; }
        public int orderCount { get; set; }
    }
}
