using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.DTOs.AdminDTOs
{
    public class UpdateAdminDTO
    {
        public int AdminId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
