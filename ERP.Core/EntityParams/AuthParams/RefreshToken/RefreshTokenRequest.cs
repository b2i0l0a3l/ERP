using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.EntityParams.AuthParams.RefreshToken
{
    public class RefreshTokenRequest
    {
        public string Email { get; set; } = string.Empty;
        public string RefreshToken { get; set; } =string.Empty;

    }
}