using Mobilya.Business.DTOs.RoleDTOs;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.DTOs.UserDTOs
{
    public class ResultUserDTO
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public List<ResultRoleDTO> Roles { get; set; }
    }
}
