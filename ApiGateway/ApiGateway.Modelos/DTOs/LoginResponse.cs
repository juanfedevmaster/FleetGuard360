using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGateway.Models.DTOs
{
    public class LoginResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
