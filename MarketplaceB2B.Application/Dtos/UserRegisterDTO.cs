﻿using MarketplaceB2B.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceB2B.Application.Dtos {
    public class UserRegisterDTO {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? TypeUser { get; set; }
    }
}
