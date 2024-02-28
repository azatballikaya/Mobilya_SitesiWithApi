using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Entity
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
