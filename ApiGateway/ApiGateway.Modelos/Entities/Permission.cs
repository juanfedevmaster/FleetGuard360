using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGateway.Models.Entities
{
    public class Permission
    {
        public Guid Id { get; set; }
        public string Name { get; set; }  // Ej: "perm.read"
        public string Description { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
