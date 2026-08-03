using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Models.AuthModels
{
    public record RegisterResponse
    {
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}