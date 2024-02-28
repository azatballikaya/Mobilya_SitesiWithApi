using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.DTOs.UserRoleDTOs
{
    public class ResultUserRoleDTO
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId{ get; set; }
        public Role Role{ get; set; }
    }
}
