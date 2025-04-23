using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGateway.Models.DTOs
{
    public class UserRoleDTO
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }

        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
