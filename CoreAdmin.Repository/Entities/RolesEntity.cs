using System;
using System.Collections.Generic;

namespace CoreAdmin.Repository.Entities
{
    public partial class RolesEntity
    {
        public RolesEntity()
        {
            EmployeeRole = new HashSet<EmployeeRoleEntity>();
        }

        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<EmployeeRoleEntity> EmployeeRole { get; set; }
    }
}
