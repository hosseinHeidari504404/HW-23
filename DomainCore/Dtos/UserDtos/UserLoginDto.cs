using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Dtos.UserDtos
{
    public class UserLoginDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
