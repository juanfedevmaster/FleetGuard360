using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGateway.Models.DTOs
{
    public class RolePermissionDTO
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
    }
}
