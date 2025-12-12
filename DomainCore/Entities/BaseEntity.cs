using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UptatedAt { get; set; }
        
    }
}
