using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGateway.Models.DTOs
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
