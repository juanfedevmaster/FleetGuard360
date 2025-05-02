using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGateway.Models.DTOs
{
    public class LoginBasicAuthResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
