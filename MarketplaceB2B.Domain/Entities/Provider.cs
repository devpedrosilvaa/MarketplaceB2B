using MarketplaceB2B.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceB2B.Domain.Entities {
    public class Provider {
        public int Id { get; set; }
        public User? User { get; set; }
        public string? AppUserId { get; set; }
        public string? CPF { get; set; }
        public StatusProvider Status { get; set; }
        public string? Description { get; set; }
    }
}
