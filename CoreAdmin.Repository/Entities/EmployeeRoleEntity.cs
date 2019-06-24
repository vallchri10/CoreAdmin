using System;
using System.Collections.Generic;

namespace CoreAdmin.Repository.Entities
{
    public partial class EmployeeRoleEntity
    {
        public string EmployeeRoleId { get; set; }
        public string EmployeeId { get; set; }
        public string RoleId { get; set; }

        public virtual RolesEntity Role { get; set; }
    }
}
