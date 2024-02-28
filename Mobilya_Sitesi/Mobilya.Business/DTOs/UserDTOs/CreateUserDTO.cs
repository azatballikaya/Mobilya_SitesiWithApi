using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
